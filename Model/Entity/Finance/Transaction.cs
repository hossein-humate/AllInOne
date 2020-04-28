using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entity.BaseInfo;

namespace Model.Entity.Finance
{
    [Table(name: "Transactions", Schema = "Finance")]
    public class Transaction : BaseEntity
    {
        ~Transaction() { Dispose(true); }

        public virtual Guid AccountId { get; set; }

        public DateTime? Date { get; set; }

        public byte Type { get; set; }

        public long Price { get; set; }

        [MaxLength(15,ErrorMessage = "تعداد 15 کاراکتر مجاز است.")]
        public string ReferenceCode { get; set; }

        [Display(Name = "نوع معامله")]
        public virtual Guid? DealTypeId { get; set; }

        public virtual Account Account { get; set; }

        public virtual MasterDetail DealType { get; set; }
    }

    public enum TransactionType : byte
    {
        InCome = 0, OutCome
    }
}
