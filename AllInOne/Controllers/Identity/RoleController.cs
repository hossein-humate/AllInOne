using System;
using System.Collections.Generic;
using System.Linq;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Entity.Identity;
using Newtonsoft.Json;
using Utility;
using static System.String;

namespace AllInOne.Controllers.Identity
{
    [Route("api/[controller]")]
    public class RoleController : ApiBaseController
    {
        [HttpGet("GetAll")]
        public IEnumerable<Role> GetAll()
        {
            var roles = UnitOfWork.Roles.Get().ToList();
            return roles;
        }

        [HttpGet("GetBySoftwareId")]
        public IEnumerable<Role> GetBySoftwareId()
        {
            var roles = UnitOfWork.Roles.Get(r =>
                r.SoftwareId == Request.Headers["SoftwareId"].ToGuid()).ToList();
            return roles;
        }

        [HttpGet("GetForSelectList")]
        public IEnumerable<SelectListItem> GetForSelectList()
        {
            var roles = UnitOfWork.Roles.Get().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();
            return roles;
        }

        [HttpPost("GetById")]
        public Role GetById(object id)
        {
            var role = UnitOfWork.Roles.GetById(id.ToGuid());
            return role;
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var role = JsonConvert.DeserializeObject<Role>(obj.ToString());
                if (role.IsDefault)
                {
                    if (UnitOfWork.Roles.Get(r =>
                            r.IsDefault && r.SoftwareId == role.SoftwareId)
                        .Any()) return "گروه دیگری به عنوان گروه پیشفرض تعریف شده است.";
                    UnitOfWork.Roles.Insert(role);
                    UnitOfWork.Save();
                    return Empty;
                }
                UnitOfWork.Roles.Insert(role);
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
                var role = JsonConvert.DeserializeObject<Role>(obj.ToString());
                var tempRole = UnitOfWork.Roles.GetById(role.Id);
                tempRole.Name = role.Name;
                tempRole.IsActive = role.IsActive;
                tempRole.Description = role.Description;
                tempRole.IsDefault = role.IsDefault;
                if (role.IsDefault)
                {
                    if (UnitOfWork.Roles.Get(r => r.Id != role.Id &&
                                                   r.IsDefault && r.SoftwareId == role.SoftwareId)
                        .Any()) return "گروه دیگری به عنوان گروه پیشفرض تعریف شده است.";
                    UnitOfWork.Roles.Update(tempRole);
                    UnitOfWork.Save();
                    return Empty;
                }
                UnitOfWork.Roles.Update(tempRole);
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
                UnitOfWork.Roles.DeleteById(id.ToGuid());
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