using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.AllInOne
{
    [Table("AssignedTask", Schema = "AllInOne")]
    public class AssignedTask : BaseEntity
    {
        public virtual Guid? PersonId { get; set; }
        public byte? Percent { get; set; }
        public long? Point { get; set; }
        public virtual int TaskChecklistId { get; set; }

        ~AssignedTask()
        {
            Dispose(true);
        }
    }
}