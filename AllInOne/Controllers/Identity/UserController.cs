using AllInOne.Infrastructure;
using AllInOne.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entity.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Model.DTO.PageModel;
using Utility;
using Utility.Helpers;
using static System.String;

namespace AllInOne.Controllers.Identity
{
    [Route("api/[controller]")]
    public class UserController : ApiBaseController
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        public UserController(IJwtAuthenticationService jwtAuthenticationService)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        [HttpGet("GetAll")]
        public IEnumerable<User> GetAll()
        {
            var users = UnitOfWork.Users.Get().ToList();
            return users;
        }

        [HttpGet("GetWithPersonBySoftwareId")]
        public IEnumerable<User> GetWithPersonBySoftwareId()
        {
            var users = UnitOfWork.Users.Get(r =>
                r.SoftwareId == Request.Headers["SoftwareId"].ToGuid())
                .Include(u => u.Person).ToList();
            var userRole = UnitOfWork.UserSoftwares.Get(us =>
                    us.SoftwareId == Request.Headers["SoftwareId"].ToGuid())
                .Include(us => us.User).Select(us => us.User).ToList();
            users = userRole.Union(users).ToList();
            return users;
        }

        [HttpPost("GetById")]
        public User GetById(object id)
        {
            var user = UnitOfWork.Users.GetById(id.ToGuid());
            return user;
        }

        [HttpPost("GetUserAllPermissions")]
        public IEnumerable<Permission> GetUserAllPermissions(object obj)
        {
            var req = JsonConvert.DeserializeObject<RequestParameters>(obj.ToString());
            var userRoles = UnitOfWork.UserRoles.Get(ur => ur.UserId == req.Param1.ToGuid()).ToList();
            IList<Permission> userPermissions = new List<Permission>();
            foreach (var item in userRoles)
            {
                var tempPermissions = UnitOfWork.RolePermissions
                    .Get(rp => rp.RoleId == item.RoleId)
                    .Include(rp => rp.Permission)
                    .Select(rp => rp.Permission)
                    .Where(p => p.SoftwareId == req.Param2.ToGuid()).ToList();
                userPermissions = userPermissions.Union(tempPermissions).ToList();
            }
            return userPermissions;
        }

        [HttpPost("GetByIdWithPerson")]
        public User GetByIdWithPerson(object id)
        {
            var user = UnitOfWork.Users.Get(u => u.Id == id.ToGuid())
                .Include(u => u.Person).FirstOrDefault();
            return user;
        }

        [HttpPost("GetByUsername")]
        public User GetByUsername(object username)
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
                    return null;
                }

                user.Mobile = user.Phones.FirstOrDefault(p =>
                    p.UserId == user.Id && p.Primary)?.Number;
                user.Email = user.Emails.FirstOrDefault(p =>
                    p.UserId == user.Id && p.Primary)?.Name;
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost("LoginUser")]
        public string LoginUser(object obj)
        {
            try
            {
                var login = JsonConvert.DeserializeObject<User>(obj.ToString());
                var validUser = UnitOfWork.Users.IsValidUser(login.Username, login.Password);
                if (validUser == null)
                {
                    return Empty;
                }

                validUser.LastLoginDate = login.LastLoginDate;
                validUser.LastLoginIp = login.LastLoginIp;
                validUser.LoginTimes = validUser.LoginTimes + 1;
                UnitOfWork.Users.Update(validUser);
                UnitOfWork.Save();
                return _jwtAuthenticationService.CreateTokenAuthentication(validUser);
            }
            catch (Exception exp)
            {
                return Empty;
            }
        }

        [HttpPost("UpdateBaseInfo")]
        public string UpdateBaseInfo(object obj)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<User>(obj.ToString());
                var validateResult = ValidateInputs(user, true);
                if (!IsNullOrWhiteSpace(validateResult))
                {
                    return validateResult;
                }

                var phone = UnitOfWork.Phones.Get(p =>
                    p.UserId == user.Id && p.Primary).FirstOrDefault();
                if (phone?.Number != user.Mobile)
                {
                    UnitOfWork.Phones.Update(new Phone
                    {
                        Type = (byte)PhoneType.Mobile,
                        Number = user.Mobile,
                        UserId = user.Id,
                        Primary = true
                    });
                }

                if (!IsNullOrWhiteSpace(user.Email))
                {
                    var email = UnitOfWork.Emails.Get(e =>
                        e.UserId == user.Id && e.Primary).FirstOrDefault();
                    if (email?.Name != user.Email)
                    {
                        UnitOfWork.Emails.Update(new Email
                        {
                            Type = (byte)EmailType.Personal,
                            Name = user.Email.ToLower(),
                            UserId = user.Id,
                            Primary = true
                        });
                    }
                }

                var passwordHash = Cryptography.CreatePasswordHash(user.Password, out var passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.SoftwareId = user.SoftwareId;
                user.IsActive = true;
                user.Username = user.Username.Trim().ToLower();
                UnitOfWork.Users.Update(user);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return Empty;
            }
        }

        [HttpPost("RegisterUser")]
        public string RegisterUser(object obj)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<User>(obj.ToString());
                var validateResult = ValidateInputs(user);
                if (!IsNullOrWhiteSpace(validateResult))
                {
                    return validateResult;
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

                //Add Public Role Access To User
                UnitOfWork.UserRoles.Insert(new UserRole
                {
                    UserId = user.Id,
                    RoleId = GlobalParameter.HumatePublicRoleId
                });

                var passwordHash = Cryptography.CreatePasswordHash(user.Password, out var passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.PersonId = person.Id;
                user.Username = user.Username.Trim().ToLower();
                UnitOfWork.Users.Insert(user);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }

        [HttpPost("RegisterAndLogin")]
        public string RegisterAndLogin(object obj)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<User>(obj.ToString());
                var validateResult = ValidateInputs(user);
                if (!IsNullOrWhiteSpace(validateResult))
                {
                    return validateResult;
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

                //Add Public Role Access To User
                UnitOfWork.UserRoles.Insert(new UserRole
                {
                    UserId = user.Id,
                    RoleId = GlobalParameter.HumatePublicRoleId
                });

                var passwordHash = Cryptography.CreatePasswordHash(user.Password, out var passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.PersonId = person.Id;
                user.Username = user.Username.Trim().ToLower();
                UnitOfWork.Users.Insert(user);
                UnitOfWork.Save();
                return _jwtAuthenticationService.CreateTokenAuthentication(user);
            }
            catch (Exception)
            {
                return Empty;
            }
        }

        [HttpPost("DeleteById")]
        public string DeleteById(object id)
        {
            try
            {
                UnitOfWork.Users.DeleteById(id.ToGuid());
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام حذف اطلاعات خطایی رخ داد!";
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