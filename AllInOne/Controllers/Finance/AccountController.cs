using System;
using System.Collections.Generic;
using System.Linq;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entity.Finance;
using Newtonsoft.Json;
using Utility;
using static System.String;

namespace AllInOne.Controllers.Finance
{
    [Route("api/[controller]")]
    public class AccountController : ApiBaseController
    {
        [HttpGet("GetAll")]
        public IEnumerable<Account> GetAll()
        {
            var accounts = UnitOfWork.Accounts.Get().ToList();
            return accounts;
        }

        [HttpGet("GetByUserId")]
        public IEnumerable<Account> GetByUserId()
        {
            var accounts = UnitOfWork.Accounts.Get(r =>
                r.UserId == Request.Headers["UserId"].ToGuid())
                .Include(a=>a.Bank).ToList();
            return accounts;
        }

        [HttpGet("GetForSelectListByUserId")]
        public IEnumerable<SelectListItem> GetForSelectListByUserId()
        {
            var roles = UnitOfWork.Accounts.Get(r =>
                r.UserId == Request.Headers["UserId"].ToGuid()).Select(p => new SelectListItem
            {
                Text = $"نام حساب: {(IsNullOrWhiteSpace(p.Name) ? "نا مشخص" : p.Name)} - " +
                       $"شماره حساب: {(IsNullOrWhiteSpace(p.Number)?"نا مشخص":p.Number)} - " +
                       $"شماره کارت: {(IsNullOrWhiteSpace(p.CardNumber) ? "نا مشخص" : p.CardNumber)}",
                Value = p.Id.ToString()
            }).ToList();
            return roles;
        }

        [HttpPost("GetById")]
        public Account GetById(object id)
        {
            var account = UnitOfWork.Accounts.GetById(id.ToGuid());
            return account;
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var account = JsonConvert.DeserializeObject<Account>(obj.ToString());
                UnitOfWork.Accounts.Insert(account);
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
                var account = JsonConvert.DeserializeObject<Account>(obj.ToString());
                var tempAccount = UnitOfWork.Accounts.GetById(account.Id);
                tempAccount.Name = account.Name;
                tempAccount.CardNumber = account.CardNumber;
                tempAccount.Number = account.Number;
                tempAccount.Price = account.Price;
                tempAccount.Type = account.Type;
                tempAccount.IsActive = true;
                tempAccount.Description = account.Description;
                UnitOfWork.Accounts.Update(tempAccount);
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
                UnitOfWork.Accounts.DeleteById(id.ToGuid());
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