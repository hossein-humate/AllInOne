using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DTO.General;
using Model.DTO.PageModel;
using Model.Entity.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;
using Utility.Helpers;
using static System.String;

namespace AllInOne.Controllers.ClientApi
{
    [Route("api/v1/[controller]")]
    public class UserController : ApiBaseController
    {
        [HttpPost("RegisterUser")]
        public ApiResult RegisterUser(object obj)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<User>(obj.ToString());
                user.Id = Guid.NewGuid();
                user.SoftwareId = Request.Headers["SoftwareId"].ToGuid();
                var validateResult = ValidateInputs(user);
                if (!IsNullOrWhiteSpace(validateResult))
                {
                    return new ApiResult
                    {
                        Value = null,
                        ErrorMessage = validateResult,
                        StatusCode = StatusCodeType.ErrorHasThrown
                    };
                }

                var person = UnitOfWork.Persons.Insert(new Person
                {
                    SoftwareId = user.SoftwareId,
                    Firstname = user.Username
                });

                UnitOfWork.Phones.Insert(new Phone
                {
                    Type = (byte)PhoneType.Mobile,
                    Number = user.Mobile,
                    UserId = user.Id,
                    Primary = true
                });

                if (!IsNullOrWhiteSpace(user.Email))
                {
                    UnitOfWork.Emails.Insert(new Email
                    {
                        Type = (byte)EmailType.Personal,
                        Name = user.Email.ToLower(),
                        UserId = user.Id,
                        Primary = true
                    });
                }

                var roleId = UnitOfWork.Roles.Get(r =>
                        r.SoftwareId == user.SoftwareId && r.IsDefault).FirstOrDefault()?.Id;
                if (roleId.HasValue)
                {
                    UnitOfWork.UserRoles.Insert(new UserRole
                    {
                        UserId = user.Id,
                        RoleId = roleId.Value
                    });
                }
                UnitOfWork.UserSoftwares.Insert(new UserSoftware
                {
                    SoftwareId = user.SoftwareId,
                    UserId = user.Id
                });

                var passwordHash = Cryptography.CreatePasswordHash(user.Password, out var passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.PersonId = person.Id;
                user.SoftwareId = person.SoftwareId;
                user.Username = user.Username.Trim().ToLower();
                UnitOfWork.Users.Insert(user);
                UnitOfWork.Save();
                return new ApiResult
                {
                    Value = user,
                    ErrorMessage = null,
                    StatusCode = StatusCodeType.Success
                }; 
            }
            catch (Exception)
            {
                return new ApiResult
                {
                    Value = null,
                    ErrorMessage = "ERROR: ذخیره اطلاعات در سرور با مشکل مواجه شد.",
                    StatusCode = StatusCodeType.ErrorHasThrown
                };
            }
        }

        [HttpPost("GetByUsername")]
        public ApiResult GetByUsername(object username)
        {
            try
            {
                var user = UnitOfWork.Users.Get(u =>
                        u.Username.ToLower() == username.ToString().ToLower().Trim())
                    .Include(u => u.Person)
                    .Include(u => u.Emails)
                    .Include(u => u.Phones).FirstOrDefault();
                if (user == null)
                {
                    return new ApiResult
                    {
                        Value = null,
                        ErrorMessage = "ERROR: کاربری با این مشخصات یافت نشد.",
                        StatusCode = StatusCodeType.ErrorHasThrown
                    };
                }

                user.Mobile = user.Phones.FirstOrDefault(p =>
                    p.UserId == user.Id && p.Primary)?.Number;
                user.Email = user.Emails.FirstOrDefault(p =>
                    p.UserId == user.Id && p.Primary)?.Name;
                return new ApiResult
                {
                    Value = user,
                    ErrorMessage = null,
                    StatusCode = StatusCodeType.Success
                };
            }
            catch (Exception)
            {
                return new ApiResult
                {
                    Value = null,
                    ErrorMessage = "ERROR: دریافت اطلاعات کاربر با مشکل مواجه شد.",
                    StatusCode = StatusCodeType.ErrorHasThrown
                };
            }
        }

        [HttpPost("ValidateUserPass")]
        public ApiResult ValidateUserPass(object obj)
        {
            try
            {
                var login = JsonConvert.DeserializeObject<User>(obj.ToString());
                var validUser = UnitOfWork.Users.IsValidUser(login.Username, login.Password);
                if (validUser == null)
                {
                    return new ApiResult
                    {
                        Value = null,
                        ErrorMessage = "ERROR: کاربری با این مشخصات یافت نشد.",
                        StatusCode = StatusCodeType.ErrorHasThrown
                    };
                }
                return new ApiResult
                {
                    Value = true,
                    ErrorMessage = null,
                    StatusCode = StatusCodeType.Success
                };
            }
            catch (Exception)
            {
                return new ApiResult
                {
                    Value = null,
                    ErrorMessage = "ERROR: احراز هویت کاربر با مشکل مواجه شد.",
                    StatusCode = StatusCodeType.ErrorHasThrown
                };
            }
        }

        [HttpPost("GetUserPermissions")]
        public ApiResult GetUserAllPermissions(object obj)
        {
            try
            {
                var req = JsonConvert.DeserializeObject<RequestParameters>(obj.ToString());
                var userRoles = UnitOfWork.UserRoles.Get(ur => ur.UserId == req.Param1.ToGuid()).ToList();
                if (userRoles.Count == 0)
                {
                    return new ApiResult
                    {
                        Value = null,
                        ErrorMessage = "ERROR: کاربری مورد نظردر هیچ گروهی عضو نیست.",
                        StatusCode = StatusCodeType.Warning
                    };
                }
                IList<Permission> userPermissions = new List<Permission>();
                userPermissions = userRoles.Select(item =>
                        UnitOfWork.RolePermissions.Get(rp => rp.RoleId == item.RoleId)
                        .Include(rp => rp.Permission)
                        .Select(rp => rp.Permission)
                        .Where(p => p.SoftwareId == req.Param2.ToGuid())
                        .ToList())
                    .Aggregate(userPermissions, (current, tempPermissions) =>
                        current.Union(tempPermissions).ToList());
                return new ApiResult
                {
                    Value = userPermissions,
                    ErrorMessage = null,
                    StatusCode = StatusCodeType.Success
                };
            }
            catch (Exception)
            {
                return new ApiResult
                {
                    Value = null,
                    ErrorMessage = "ERROR: پایش اطلاعات دسترسی کاربر با مشکل مواجه شد.",
                    StatusCode = StatusCodeType.ErrorHasThrown
                };
            }
        }

        private string ValidateInputs(User model, bool updateMode = false)
        {
            var users = UnitOfWork.Users.Get();
            var phones = UnitOfWork.Phones.Get();
            var emails = UnitOfWork.Emails.Get();
            if (updateMode)
            {
                if (users.Any(u => u.Username == model.Username && u.Id != model.Id))
                {
                    return "ERROR: نام کاربری وارد شده متعلق به شخص دیگری است.";
                }
                if (emails.Any(u => u.Name == model.Email && u.UserId != model.Id))
                {
                    return "ERROR: پست الکترونیکی وارد شده متعلق به شخص دیگری است.";
                }
                if (phones.Any(u => u.Number == model.Mobile && u.UserId != model.Id))
                {
                    return "ERROR: شماره تلفن همراه وارد شده متعلق به شخص دیگری است.";
                }
                return Empty;
            }

            if (users.Any(u => u.Username == model.Username))
            {
                return "ERROR: نام کاربری وارد شده قبل ذخبره شده است.";
            }
            if (emails.Any(u => u.Name == model.Email))
            {
                return "ERROR: پست الکترونیکی وارد شده قبل ذخبره شده است.";
            }
            if (phones.Any(u => u.Number == model.Mobile))
            {
                return "ERROR: شماره تلفن همراه وارد شده قبل ذخبره شده است.";
            }
            return Empty;
        }
    }
}