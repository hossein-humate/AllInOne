using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entity.Finance;

namespace Model.Entity.BaseInfo
{
    [Table(name: "MasterDetails", Schema = "BaseInfo")]
    public class MasterDetail : BaseEntity
    {
        ~MasterDetail() { Dispose(true); }

        [StringLength(100)]
        [Required(ErrorMessage = "تکميل فيلد {0} الزامی است!")]
        [Display(Name = "نام فارسی")]
        public string FaName { get; set; }

        [StringLength(100)]
        [Display(Name = "نام انگلیسی")]
        public string EnName { get; set; }

        [StringLength(100)]
        [Display(Name = "عنوان پارامتر")]
        public string Title { get; set; }

        [Required(ErrorMessage = "تکميل فيلد {0} الزامی است!")]
        [Display(Name = "شناسه پدر")]
        public Guid MasterId { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int? Order { get; set; }

        public virtual MasterDetail Master { get; set; }
        public virtual IList<MasterDetail> Details { get; set; }

        //Related Entities
        public virtual IList<Account> Accounts { get; set; }
        public virtual IList<Transaction> Transactions { get; set; }
    }
}