using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entity.Finance;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;
using static System.String;

namespace AllInOne.Controllers.Finance
{
    [Route("api/[controller]")]
    public class TransactionController : ApiBaseController
    {
        [HttpGet("GetAll")]
        public IEnumerable<Transaction> GetAll()
        {
            var transactions = UnitOfWork.Transactions.Get().ToList();
            return transactions;
        }

        [HttpGet("GetByUserId")]
        public IEnumerable<Transaction> GetByUserId()
        {
            var transactions = UnitOfWork.Transactions.Get()
                .Include(a => a.Account).Where(t =>
                    t.Account.UserId == Request.Headers["UserId"].ToGuid())
                .Include(a => a.DealType)
                .ToList();
            return transactions;
        }

        [HttpPost("GetById")]
        public Transaction GetById(object id)
        {
            var transaction = UnitOfWork.Transactions.Get(t=>t.Id==id.ToGuid())
                .Include(t=>t.Account).FirstOrDefault();
            return transaction;
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var transaction = JsonConvert.DeserializeObject<Transaction>(obj.ToString());
                //Update Related Account Price
                UpdateAccountPrice(transaction.AccountId, transaction.Price,
                    (TransactionType)transaction.Type);
                UnitOfWork.Transactions.Insert(transaction);
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
                var transaction = JsonConvert.DeserializeObject<Transaction>(obj.ToString());
                var tempTransaction = UnitOfWork.Transactions.GetById(transaction.Id);
                //Update Related Account Price
                if (tempTransaction.Type == transaction.Type)
                {
                    UpdateAccountPrice(transaction.AccountId, tempTransaction.Price - transaction.Price,
                        (TransactionType)transaction.Type);
                }
                else
                {
                    UpdateAccountPrice(transaction.AccountId, tempTransaction.Price + transaction.Price,
                        (TransactionType)transaction.Type);
                }

                tempTransaction.AccountId = transaction.AccountId;
                tempTransaction.DealTypeId = transaction.DealTypeId;
                tempTransaction.ReferenceCode = transaction.ReferenceCode;
                tempTransaction.Price = transaction.Price;
                tempTransaction.Type = transaction.Type;
                tempTransaction.Date = transaction.Date;
                tempTransaction.IsActive = true;
                tempTransaction.Description = transaction.Description;
                UnitOfWork.Transactions.Update(tempTransaction);
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
                var transation = UnitOfWork.Transactions.GetById(id.ToGuid());
                UpdateAccountPrice(transation.AccountId, -transation.Price, (TransactionType) transation.Type);
                UnitOfWork.Transactions.DeleteById(id.ToGuid());
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام حذف اطلاعات خطایی رخ داد!";
            }
        }

        private void UpdateAccountPrice(Guid accountId, long price, TransactionType type)
        {
            var tempAccount = UnitOfWork.Accounts.GetById(accountId);
            if (type == TransactionType.InCome)
            {
                tempAccount.Price += price;
            }
            else
            {
                tempAccount.Price -= price;
            }
            tempAccount.LastModifiedDate = DateTime.Now;
            UnitOfWork.Accounts.Update(tempAccount);
            UnitOfWork.Save();
        }
    }
}