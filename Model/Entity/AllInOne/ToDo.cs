using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.AllInOne
{
    [Table("ToDo", Schema = "AllInOne")]
    public class ToDo : BaseEntity
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public int? ProjectId { get; set; }
        public int? ContractId { get; set; }
        public virtual Guid OwnerId { get; set; }

        ~ToDo()
        {
            Dispose(true);
        }
    }
}