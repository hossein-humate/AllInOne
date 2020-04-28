using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entity.Identity;

namespace Model.Entity.Application
{
    [Table("Software", Schema = "Application")]
    public class Software : BaseEntity
    {
        [Display(Name = "نام فارسی نرم افزار")]
        [Required(ErrorMessage = "نام فارسی نرم افزار را وارد نمایید")]
        public string FaName { get; set; }

        [Display(Name = "نام انگلیسی نرم افزار")]
        public string EnName { get; set; }

        [Display(Name = "زبان برنامه نویسی")] 
        public string ProgrammingLanguage { get; set; }

        [Display(Name = "الگوی توسعه پذیری")] 
        public string Methodology { get; set; }

        public string ApiKey { get; set; }

        public Guid OwnerId { get; set; }

        public virtual IList<UserSoftware> UserSoftwares { get; set; }

        ~Software()
        {
            Dispose(true);
        }
    }
}