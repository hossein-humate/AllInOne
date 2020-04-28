using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.AllInOne
{
    [Table("Developer", Schema = "AllInOne")]
    public class Developer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PostId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        ~Developer()
        {
            Dispose(true);
        }
    }
}