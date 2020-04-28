using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.AllInOne
{
    [Table("WorkSheet", Schema = "AllInOne")]
    public class WorkSheet : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Guid ContractId { get; set; }

        ~WorkSheet()
        {
            Dispose(true);
        }
    }
}