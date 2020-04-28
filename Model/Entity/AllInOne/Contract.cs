using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.AllInOne
{
    [Table("Contract", Schema = "AllInOne")]
    public class Contract : BaseEntity
    {
        public string Title { get; set; }
        public string ContractCode { get; set; }
        public Guid PaymentTypeId { get; set; }
        public double Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public virtual Guid ProjectId { get; set; }
        public virtual Guid CustomerId { get; set; }
        public virtual Guid DeveloperId { get; set; }

        ~Contract()
        {
            Dispose(true);
        }
    }
}