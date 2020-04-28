using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "Roles", Schema = "Identity")]
    public class Role : BaseEntity
    {
        ~Role(){Dispose(true);}

        [Required(ErrorMessage = "وارد کردن شناسه نرم افزار الزامی میباشد")]
        public Guid SoftwareId { get; set; }

        [Display(Name = "نام گروه")]
        public string Name { get; set; }

        [DefaultValue(false)]
        [Display(Name = "پیشفرض کاربران جدید")]
        public bool IsDefault { get; set; }

        public virtual IList<RolePermission> RolePermissions { get; set; }
        public virtual IList<UserRole> UserRoles { get; set; }
    }
}
