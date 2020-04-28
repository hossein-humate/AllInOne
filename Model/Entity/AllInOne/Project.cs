using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.AllInOne
{
    [Table("Project", Schema = "AllInOne")]
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public virtual Guid? TeamLeaderId { get; set; }
        public string StartDate { get; set; }
        public int? WorkItemProcessId { get; set; }
        public int? VersionControlId { get; set; }

        ~Project()
        {
            Dispose(true);
        }
    }
}