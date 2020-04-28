using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.AllInOne
{
    [Table("Customer", Schema = "AllInOne")]
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public virtual Guid? CEOCompanyId { get; set; }

        ~Customer()
        {
            Dispose(true);
        }
    }
}