using System;
using System.Collections.Generic;
using System.Linq;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.DTO.PageModel;
using Model.Entity.Identity;
using Newtonsoft.Json;
using Utility;
using static System.String;

namespace AllInOne.Controllers.Identity
{
    [Route("api/[controller]")]
    public class PermissionController : ApiBaseController
    {
        [HttpGet("GetAll")]
        public IEnumerable<Permission> GetAll()
        {
            var permissions = UnitOfWork.Permissions.Get().ToList();
            return permissions;
        }

        [HttpGet("GetAllPermissionListForTreeViewBySoftwareId")]
        public IEnumerable<JsTree> GetAllPermissionListForTreeViewBySoftwareId()
        {
            var jsTreeItems = UnitOfWork.Permissions.Get(p =>
                p.SoftwareId == Request.Headers["SoftwareId"].ToGuid()).Select(p => new JsTree()
                {
                    id = p.Id.ToString(),
                    parent = p.ParentId == Guid.Empty ? "#" : p.ParentId.ToString(),
                    text = p.FaName,
                    state = new JsTreeState
                    {
                        opened = p.ParentId == Guid.Empty || p.Childrens.Any(),
                        selected = p.ParentId == Guid.Empty
                    }
                }).ToList();
            return jsTreeItems;
        }

        [HttpGet("GetForSelectList")]
        public IEnumerable<SelectListItem> GetForSelectList()
        {
            var permissions = UnitOfWork.Permissions.Get().Select(p => new SelectListItem
            {
                Text = p.FaName + "/" + p.EnName,
                Value = p.Id.ToString()
            }).ToList();
            return permissions;
        }

        [HttpPost("GetById")]
        public Permission GetById(object id)
        {
            var permission = UnitOfWork.Permissions.GetById(id.ToGuid());
            return permission;
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var permission = JsonConvert.DeserializeObject<Permission>(obj.ToString());
                UnitOfWork.Permissions.Insert(permission);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }

        [HttpPost("Update")]
        public string Update(object obj)
        {
            try
            {
                var permission = JsonConvert.DeserializeObject<Permission>(obj.ToString());
                var tempPermission = UnitOfWork.Permissions.GetById(permission.Id);
                tempPermission.FaName = permission.FaName;
                tempPermission.EnName = permission.EnName;
                tempPermission.Action = permission.Action;
                tempPermission.Type = permission.Type;
                tempPermission.SortOrder = permission.SortOrder;
                tempPermission.Public = permission.Public;
                tempPermission.ParentId = permission.ParentId;
                tempPermission.SoftwareId = permission.SoftwareId;
                tempPermission.IsActive = true;
                tempPermission.Description = permission.Description;
                UnitOfWork.Permissions.Update(tempPermission);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }

        [HttpPost("DeleteById")]
        public string DeleteById(object id)
        {
            try
            {
                var childItems = UnitOfWork.Permissions.Get(p => p.ParentId == id.ToGuid()).ToList();
                if (childItems.Any())
                {
                    Response.StatusCode = 500;
                    return "ابتدا فرزندان این شاخه را حذف نمایید.";
                }
                UnitOfWork.Permissions.DeleteById(id.ToGuid());
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام حذف اطلاعات خطایی رخ داد!";
            }
        }
    }
}