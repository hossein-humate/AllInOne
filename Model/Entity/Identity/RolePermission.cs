using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "RolePermissions", Schema = "Identity")]
    public class RolePermission : BaseEntity
    {
        ~RolePermission(){Dispose(true);}

        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual Role Role { get; set; }
    }
}
