using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "Emails", Schema = "Identity")]
    public class Email : BaseEntity
    {
        ~Email() { Dispose(true); }

        public virtual Guid UserId { get; set; }

        [Display(Name = " نام پست الکترونیکی")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$",
            ErrorMessage = "ساختار ایمیل صحیح نمی\x200Cباشد")]
        public string Name { get; set; }

        [DefaultValue(false)]
        [Display(Name = "پست الکترونیکی اصلی")]
        public bool Primary { get; set; }

        [Display(Name = "تایید شده")]
        [DefaultValue(false)]
        public bool Confirmed { get; set; }

        [Display(Name = " نوع پست الکترونیکی")]
        public byte Type { get; set; }

        public virtual User User { get; set; }
    }
    public enum EmailType : byte
    {
        Personal,
        Work,
        Office,
    }
}
