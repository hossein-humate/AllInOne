using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Model.Entity.Application;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.DTO.PageModel;
using Model.Entity.Identity;
using Utility;

namespace AllInOne.Controllers.Application
{
    [Route("api/[controller]")]
    public class SoftwareController : ApiBaseController
    {
        [HttpGet("GetAll")]
        public IEnumerable<Software> GetAll()
        {
            var software = UnitOfWork.Softwares.Get(s => s.IsDeleted == false);
            return software;
        }


        [HttpPost("GetByUserId")]
        public IEnumerable<Software> GetByUserId(object id)
        {
            return UnitOfWork.UserSoftwares.Get(us => us.UserId == id.ToGuid())
                .Include(us => us.Software).Select(us => us.Software);
        }

        [HttpPost("GetById")]
        public Software GetById(object id)
        {
            var software = UnitOfWork.Softwares.GetById(Guid.Parse(id.ToString()));
            return software;
        }

        [HttpPost("UpdateApiKey")]
        public string UpdateApiKey()
        {
            try
            {
                var tempSoftware = UnitOfWork.Softwares.GetById(Request.Headers["SoftwareId"].ToGuid());
                tempSoftware.ApiKey = Request.Headers["ApiKey"].ToString();
                tempSoftware.IsActive = true;
                UnitOfWork.Softwares.Update(tempSoftware);
                UnitOfWork.Save();
                return string.Empty;
            }
            catch (Exception)
            {
                return "ذخیره اطلاعات با مشکل مواجه شد";
            }
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var software = JsonConvert.DeserializeObject<Software>(obj.ToString());
                string validateMassage = IsValidInputs(software);
                if (!string.IsNullOrWhiteSpace(validateMassage))
                {
                    return validateMassage;
                }
                //Create An Access for User Who Enter This Software
                UnitOfWork.UserSoftwares.Insert(new UserSoftware
                {
                    UserId = Request.Headers["UserId"].ToGuid(),
                    SoftwareId = software.Id
                });
                //Create Head Item of Permissions
                UnitOfWork.Permissions.Insert(new Permission
                {
                    SoftwareId = software.Id,
                    FaName = software.FaName,
                    EnName = software.EnName,
                    ParentId = Guid.Empty,
                    Action = "/",
                    SortOrder = 1,
                    Public = true,
                    Type = PermissionType.Link,
                    IsActive = true
                });
                software.IsActive = true;
                UnitOfWork.Softwares.Insert(software);
                UnitOfWork.Save();
                return string.Empty;
            }
            catch (Exception)
            {
                return "ذخیره اطلاعات با مشکل مواجه شد";
            }
        }

        [HttpPost("Update")]
        public string Update(object obj)
        {
            try
            {
                var software = JsonConvert.DeserializeObject<Software>(obj.ToString());
                string validateMassage = IsValidInputs(software, true);
                if (!string.IsNullOrWhiteSpace(validateMassage))
                {
                    return validateMassage;
                }
                var tempSoftware = UnitOfWork.Softwares.GetById(software.Id);
                tempSoftware.FaName = software.FaName;
                tempSoftware.EnName = software.EnName;
                tempSoftware.ProgrammingLanguage = software.ProgrammingLanguage;
                tempSoftware.Methodology = software.Methodology;
                tempSoftware.IsActive = true;
                tempSoftware.Description = software.Description;
                UnitOfWork.Softwares.Update(tempSoftware);
                UnitOfWork.Save();
                return string.Empty;
            }
            catch (Exception)
            {
                return "ذخیره اطلاعات با مشکل مواجه شد";
            }
        }

        [HttpPost("DeleteById")]
        public bool DeleteById(object id)
        {
            try
            {
                var result = UnitOfWork.Softwares.DeleteById(Guid.Parse(id.ToString()));
                //Delete Related Tables Data
                UnitOfWork.UserSoftwares.DeleteRangePhysical(UnitOfWork.UserSoftwares.Get(us =>
                    us.SoftwareId == id.ToGuid()));
                var relatedRoles = UnitOfWork.Roles.Get(r => r.SoftwareId == id.ToGuid());
                foreach (var item in relatedRoles)
                {
                    if (UnitOfWork.UserRoles.GetAsNoTracking(ur => ur.RoleId == item.Id) != null)
                    {
                        UnitOfWork.UserRoles.DeletePhysical(UnitOfWork.UserRoles.GetAsNoTracking(ur =>
                            ur.RoleId == item.Id));
                    }
                    if (UnitOfWork.RolePermissions.GetAsNoTracking(rp => rp.RoleId == item.Id) != null)
                    {
                        UnitOfWork.RolePermissions.DeletePhysical(
                            UnitOfWork.RolePermissions.GetAsNoTracking(rp => rp.RoleId == item.Id));
                    }
                }
                UnitOfWork.Roles.DeleteRangePhysical(relatedRoles);
                UnitOfWork.Save();
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string IsValidInputs(Software entity, bool editMode = false)
        {
            try
            {
                if (editMode)
                {
                    if (UnitOfWork.Softwares.Get().Any(u => u.FaName == entity.FaName && u.Id != entity.Id))
                    {
                        return "نام نرم افزار تکراری است";
                    }
                }
                else
                {
                    if (UnitOfWork.Softwares.Get().Any(u => u.FaName == entity.FaName))
                    {
                        return "نام نرم افزار وارد شده تکراری است.";
                    }
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}