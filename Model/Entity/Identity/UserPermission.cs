using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table("UserPermission", Schema = "Identity")]
    public class UserPermission : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid PermissionId { get; set; }

        [DefaultValue(false)] public bool Access { get; set; }

        [DefaultValue(false)] public bool Public { get; set; }

        ~UserPermission()
        {
            Dispose(true);
        }
    }
}