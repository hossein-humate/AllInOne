using System;
using System.Collections.Generic;
using System.Linq;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utility;
using Utility.Helpers;

namespace AllInOne.Controllers.Identity
{
    [Route("api/[controller]")]
    public class VisitorController : ApiBaseController
    {
        [HttpGet("GetAll")]
        public IEnumerable<Model.Entity.Identity.Visitor> GetAll()
        {
            var visitors = UnitOfWork.Visitors.Get().ToList();
            return visitors;
        }

        [HttpGet("GetDailyLastWeek")]
        public JsonResult GetDailyLastWeek()
        {
            var lastWeekDate = DateTime.Now.AddDays(-7);
            var visitors = UnitOfWork.Visitors.Get().Where(v =>
                lastWeekDate < v.CreationDate).Select(v => new
                {
                    v.Id,
                    CreationDate = v.CreationDate.GetPersianDateTime()
                }).ToList();
            var lastWeek = visitors.GroupBy(v => v.CreationDate).Select(v => new
            {
                Count = visitors.Count(x => x.CreationDate == v.Key),
                Date = v.Key,
                DayOfWeek = v.Key.GetPersianDayOfWeek()
            }).OrderBy(l=>l.Date).ToList();
            return new JsonResult(lastWeek);
        }

        [HttpPost("GetById")]
        public Model.Entity.Identity.Visitor GetById(object id)
        {
            var visitor = UnitOfWork.Visitors.GetById(id.ToGuid());
            return visitor;
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var visitor = JsonConvert.DeserializeObject<Model.Entity.Identity.Visitor>(obj.ToString());
                UnitOfWork.Visitors.Insert(visitor);
                UnitOfWork.Save();
                return string.Empty;
            }
            catch (Exception exp)
            {
                //return exp.Message + "\n" + exp.InnerException?.Message;
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }
    }
}