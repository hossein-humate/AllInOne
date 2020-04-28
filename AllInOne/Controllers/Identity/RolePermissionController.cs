using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Model.DTO.PageModel;
using Model.Entity.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace AllInOne.Controllers.Identity
{
    [Route("api/[controller]")]
    public class RolePermissionController : ApiBaseController
    {
        [HttpGet("GetAllRolePermissionListForTreeViewBySoftwareId")]
        public IEnumerable<JsTree> GetAllRolePermissionListForTreeViewBySoftwareId()
        {
            var jsTreeItems = UnitOfWork.Permissions.Get(p =>
                p.SoftwareId == Request.Headers["SoftwareId"].ToGuid())
                .Select(p => new JsTree()
                {
                    id = p.Id.ToString(),
                    parent = p.ParentId == Guid.Empty ? "#" : p.ParentId.ToString(),
                    text = p.FaName,
                    state = new JsTreeState
                    {
                        opened = p.ParentId == Guid.Empty || p.Childrens.Any(),
                        selected = p.ParentId == Guid.Empty,
                        Checked = p.RolePermissions.Any(item => item.RoleId == Request.Headers["RoleId"].ToGuid())
                    }
                }).ToList();
            return jsTreeItems;
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var req = JsonConvert.DeserializeObject<RequestParameters>(obj.ToString());
                UnitOfWork.RolePermissions.DeleteRangePhysical(UnitOfWork.RolePermissions.Get(rp =>
                    rp.RoleId == req.Param1.ToGuid()));
                var rolePermissions = req.Param2.ToString()
                    .Split(",")
                    .Select(permissionId => new RolePermission
                    {
                        RoleId = req.Param1.ToGuid(),
                        PermissionId = permissionId.ToGuid(),
                        IsDeleted = false,
                        IsActive = true,
                        CreationDate = DateTime.Now,
                        LastModifiedDate = DateTime.Now
                    })
                    .ToList();
                UnitOfWork.RolePermissions.InsertRange(rolePermissions);
                UnitOfWork.Save();
                return string.Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }
    }
}