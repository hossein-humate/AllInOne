using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility;

namespace Model.Entity.Blog
{
    [Table(name: "DocumentImages", Schema = "Blog")]
    public class DocumentImage : BaseEntity
    {
        ~DocumentImage() { Dispose(true); }

        [Display(Name = "نام تصویر")]
        [Required(ErrorMessage = "وارد کردن فیلد نام تصویر اجباری است")]
        public string Name { get; set; }

        [Display(Name = "متن جایگزین")]
        public string Alt { get; set; }

        [Display(Name = "پانویس")]
        public string Caption { get; set; }

        [Display(Name = "طول")]
        public string Width { get; set; }

        [Display(Name = "ارتفاع")]
        public string Height { get; set; }

        public virtual Guid DocumentId { get; set; }

        public virtual Document Document { get; set; }

        [NotMapped]
        public string ImageUrl =>
            string.IsNullOrEmpty(Name) ? String.Empty :
                string.Concat(GlobalParameter.CdnDomainUrl, GlobalParameter.DocumentImagePath, Name);
    }
}