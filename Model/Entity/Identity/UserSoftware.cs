using Model.Entity.Application;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "UserSoftwares", Schema = "Identity")]
    public class UserSoftware : BaseEntity
    {
        ~UserSoftware() { Dispose(true); }
        public Guid UserId { get; set; }

        public Guid SoftwareId { get; set; }

        public virtual User User { get; set; }

        public virtual Software Software { get; set; }
    }
}
