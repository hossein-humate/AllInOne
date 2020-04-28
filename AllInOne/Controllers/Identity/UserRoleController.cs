using System;
using System.Collections.Generic;
using System.Linq;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DTO.PageModel;
using Model.Entity.Identity;
using Newtonsoft.Json;
using Utility;

namespace AllInOne.Controllers.Identity
{
    [Route("api/[controller]")]
    public class UserRoleController : ApiBaseController
    {
        [HttpGet("GetAllUserRoleForTreeViewByUserIdSoftwareId")]
        public IEnumerable<JsTree> GetAllUserRoleForTreeViewByUserIdSoftwareId()
        {
            var roles = UnitOfWork.Roles.Get(r =>
                r.SoftwareId == Request.Headers["SoftwareId"].ToGuid()).Include(r => r.UserRoles).ToList();
            roles.Add(new Role
            {
                Id = Guid.Empty,
                Name = "گروه ها",
                UserRoles = new List<UserRole>()
            });
            var jsTreeItems = roles.Select(r => new JsTree()
            {
                id = r.Id.ToString(),
                parent = r.Id == Guid.Empty ? "#" : Guid.Empty.ToString(),
                text = r.Name,
                state = new JsTreeState
                {
                    opened = r.Id == Guid.Empty,
                    selected = r.Id == Guid.Empty,
                    Checked = r.UserRoles.Any(item => item.UserId == Request.Headers["UserId"].ToGuid())
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
                
                UnitOfWork.UserRoles.DeleteRangePhysical(UnitOfWork.UserRoles.Get(ur =>
                        ur.UserId == req.Param1.ToGuid()).Include(r => r.Role)
                    .Where(r => r.Role.SoftwareId == req.Param3.ToGuid()));

                var roles = req.Param2.ToString().Split(",").ToList();
                roles.Remove(Guid.Empty.ToString());
                var userRole = roles.Select(roleId => new UserRole()
                {
                    UserId = req.Param1.ToGuid(),
                    RoleId = roleId.ToGuid(),
                    IsDeleted = false,
                    IsActive = true,
                    CreationDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                })
                    .ToList();
                UnitOfWork.UserRoles.InsertRange(userRole);
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