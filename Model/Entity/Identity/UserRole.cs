using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "UserRoles", Schema = "Identity")]
    public class UserRole:BaseEntity
    {
        ~UserRole(){Dispose(true);}

        public Guid UserId { get; set; }
        
        public Guid RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
