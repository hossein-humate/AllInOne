using Model.Entity.BaseInfo;
using Model.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Finance
{
    [Table(name: "Accounts", Schema = "Finance")]
    public class Account : BaseEntity
    {
        ~Account() { Dispose(true); }

        public virtual Guid? UserId { get; set; }

        public virtual Guid? BankId { get; set; }

        public string Name { get; set; }

        public string CardNumber { get; set; }

        public byte Type { get; set; }

        [DefaultValue(0)]
        public long Price { get; set; }

        public string Number { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }

        public virtual MasterDetail Bank { get; set; }

        public virtual User User { get; set; }
    }

    public enum AccountType : byte
    {
        RoozShomar = 0,
        Jari,
        Vam,
        GharzolHasane
    }
}
