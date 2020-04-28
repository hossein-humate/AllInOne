using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Application
{
    [Table("Database", Schema = "Application")]
    public class Database : BaseEntity
    {
        public string DataSource { get; set; }
        public string DbType { get; set; }
        public string ServerName { get; set; }
        public string Provider { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        ~Database()
        {
            Dispose(true);
        }
    }
}