using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility;

namespace Model.Entity.Identity
{
    [Table(name: "Persons", Schema = "Identity")]
    public class Person : BaseEntity
    {
        ~Person(){Dispose(true);}

        [Required(ErrorMessage = "وارد کردن شناسه نرم افزار الزامی میباشد")]
        public Guid SoftwareId { get; set; }

        [Required(ErrorMessage = "وارد نمودن نام الزامی است")]
        [Display(Name = "نام")]
        public string Firstname { get; set; }

        [Display(Name = "نام مستعار")]
        public string Middlename { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string Lastname { get; set; }

        [Display(Name = "کد ملی")]
        [StringLength(10, ErrorMessage = "کد ملی دارای فرمت نامعتبر است")]
        [MaxLength(10, ErrorMessage = "کد ملی دارای فرمت نامعتبر است")]
        [MinLength(10, ErrorMessage = "کد ملی دارای فرمت نامعتبر است")]
        [RegularExpression(@"\d*", ErrorMessage = "کد ملی فقط دارای اعداد می باشد")]
        public string NationalId { get; set; }

        [Display(Name = "تصویر")]
        public string PicturePath { get; set; }

        [Display(Name = "جنسیت")]
        public byte Gender { get; set; }

        public virtual IList<User> Users { get; set; }

        [NotMapped]
        public string PersonPictureUrl => string.IsNullOrEmpty(PicturePath) ? string.Empty :
            string.Concat(GlobalParameter.CdnDomainUrl, GlobalParameter.PersonImagePath, PicturePath);
    }
    public enum GenderType : byte
    {
        Male,
        Female,
        NotInterest
    }
}
