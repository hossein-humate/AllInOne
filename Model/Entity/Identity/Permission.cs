using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "Permissions", Schema = "Identity")]
    public class Permission : BaseEntity
    {
        ~Permission(){Dispose(true);}

        [Required(ErrorMessage = "وارد کردن شناسه نرم افزار الزامی میباشد")]
        public Guid SoftwareId { get; set; }

        [DisplayName("نام فارسی")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string FaName { get; set; }

        [DisplayName("نام انگلیسی")]
        public string EnName { get; set; }

        [DisplayName("عملکرد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string Action { get; set; }

        public Guid ParentId { get; set; }

        [DisplayName("نوع مجوز")]
        public PermissionType Type { get; set; }

        [DisplayName("شماره ترتیب")]
        public short SortOrder { get; set; }

        [DefaultValue(false)]
        [DisplayName("دسترسی عمومی")]
        public bool Public { get; set; }

        public string Icon { get; set; }

        public virtual Permission Parent { get; set; }

        public virtual IList<Permission> Childrens { get; set; }

        public virtual IList<RolePermission> RolePermissions { get; set; }
    }
    public enum PermissionType : byte
    {
        Menu=0,
        Event,
        CommonMethod,
        ActionResult,
        Component,
        UserControl,
        Control,
        Link,
        Service,
        Page,
        PartialView
    }
}
