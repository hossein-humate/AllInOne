using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.AllInOne
{
    [Table("TaskChecklist", Schema = "AllInOne")]
    public class TaskChecklist : BaseEntity
    {
        public string Title { get; set; }
        public int? Priority { get; set; }
        public string TagId { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public virtual int ToDoId { get; set; }
        public byte Status { get; set; }
        public bool Active { get; set; }
        public long? Score { get; set; }

        ~TaskChecklist()
        {
            Dispose(true);
        }
    }
}