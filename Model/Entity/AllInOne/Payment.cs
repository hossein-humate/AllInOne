using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.AllInOne
{
    [Table("Payment", Schema = "AllInOne")]
    public class Payment : BaseEntity
    {
        public double Price { get; set; }
        public DateTime PayDate { get; set; }
        public virtual Guid ContractId { get; set; }

        ~Payment()
        {
            Dispose(true);
        }
    }
}