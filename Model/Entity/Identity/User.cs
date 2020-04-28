using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entity.Finance;

namespace Model.Entity.Identity
{
    [Table(name: "Users", Schema = "Identity")]
    public class User : BaseEntity
    {
        ~User() { Dispose(true); }

        [Required(ErrorMessage = "وارد کردن شناسه نرم افزار الزامی میباشد")]
        public Guid SoftwareId { get; set; }

        [Display(Name = "نام کاربری")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "تکميل فيلد {0} الزامی است!")]
        public string Username { get; set; }

        public DateTime? LastLoginDate { get; set; }

        [StringLength(20)]
        public string RegisterIp { get; set; }

        public DateTime? RegisterDate { get; set; }

        [DefaultValue(0)]
        public int LoginTimes { get; set; }

        [StringLength(20)]
        public string LastLoginIp { get; set; }

        [Display(Name = "گذر واژه")]
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تکميل فيلد {0} الزامی است!")]
        [MinLength(6, ErrorMessage = "گذرواژه حداقل شامل 6 کاراکتر باشد")]
        [Display(Name = "گذرواژه")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual Guid? PersonId { get; set; }

        public bool TwoFactorEnable { get; set; }

        public virtual Guid? TwoFactorPhoneId { get; set; }

        public virtual Guid? TwoFactorEmailId { get; set; }

        public virtual IList<Email> Emails { get; set; }

        public virtual IList<Phone> Phones { get; set; }

        public virtual IList<Address> Addresses { get; set; }

        public virtual IList<UserRole> UserRoles { get; set; }

        public virtual IList<UserSoftware> UserSoftwares { get; set; }

        public virtual IList<Account> Accounts { get; set; }

        public virtual Person Person { get; set; }

        [NotMapped]
        [Display(Name = "شماره تلفن همراه")]
        [RegularExpression("([0-9]+)", ErrorMessage = "شماره تلفن همراه نا معتبر است")]
        [MaxLength(11, ErrorMessage = "تلفن همراه را به صورت 09121234567 کامل وارد کنید")]
        [MinLength(11, ErrorMessage = "تلفن همراه را به صورت 09121234567 کامل وارد کنید")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "تکميل فيلد {0} الزامی است!")]
        public string Mobile { get; set; }

        [NotMapped]
        [RegularExpression(
            "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$",
            ErrorMessage = "ساختار ایمیل صحیح نمی\x200Cباشد")]
        public string Email { get; set; }

        [NotMapped]
        [Required(AllowEmptyStrings = false, ErrorMessage = "تکميل فيلد {0} الزامی است!")]
        [Display(Name = "تکرار گذرواژه")]
        [Compare("Password", ErrorMessage = "گذرواژه ها باید یکسان باشند.")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}
