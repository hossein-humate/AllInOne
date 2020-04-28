using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DTO.PageModel;
using Model.Entity.Application;
using Model.Entity.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace AllInOne.Controllers.Identity
{
    [Route("api/[controller]")]
    public class UserSoftwareController : ApiBaseController
    {
        [HttpGet("GetAllUserSoftwareForTreeViewByUserId")]
        public IEnumerable<JsTree> GetAllUserSoftwareForTreeViewByUserId()
        {
            var softwares = UnitOfWork.Softwares.Get().Include(r => r.UserSoftwares).ToList();
            softwares.Add(new Software
            {
                Id = Guid.Empty,
                FaName = "نرم افزار ها",
                UserSoftwares = new List<UserSoftware>()
            });
            var jsTreeItems = softwares.Select(r => new JsTree()
            {
                id = r.Id.ToString(),
                parent = r.Id == Guid.Empty ? "#" : Guid.Empty.ToString(),
                text = r.FaName,
                state = new JsTreeState
                {
                    opened = r.Id == Guid.Empty,
                    selected = r.Id == Guid.Empty,
                    Checked = r.UserSoftwares.Any(item => item.UserId == Request.Headers["UserId"].ToGuid())
                }
            }).ToList();
            return jsTreeItems;
        }

        [HttpPost("CreateRange")]
        public string CreateRange(object obj)
        {
            try
            {
                var req = JsonConvert.DeserializeObject<RequestParameters>(obj.ToString());
                UnitOfWork.UserSoftwares.DeleteRangePhysical(UnitOfWork.UserSoftwares.Get(ur =>
                    ur.UserId == req.Param1.ToGuid()));
                var softwares = req.Param2.ToString().Split(",").ToList();
                softwares.Remove(Guid.Empty.ToString());
                var userSoftwares = softwares.Select(softwareId => new UserSoftware()
                {
                    UserId = req.Param1.ToGuid(),
                    SoftwareId = softwareId.ToGuid(),
                    IsDeleted = false,
                    IsActive = true,
                    CreationDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }).ToList();
                UnitOfWork.UserSoftwares.InsertRange(userSoftwares);
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