using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "Phones", Schema = "Identity")]
    public class Phone : BaseEntity
    {
        ~Phone(){Dispose(true);}

        public virtual Guid UserId { get; set; }

        [Display(Name = "شماره تلفن")]
        public string Number { get; set; }

        [Display(Name = "کد کشور")]
        public string CountryCode { get; set; }

        [Display(Name = "کد شهر")]
        public string CityCode { get; set; }

        [DefaultValue(false)]
        [Display(Name = "شماره تلفن اصلی")]
        public bool Primary { get; set; }

        [Display(Name = "تایید شده")]
        [DefaultValue(false)]
        public bool Confirmed { get; set; }

        public byte Type { get; set; }

        public virtual User User { get; set; }
    }
    public enum PhoneType : byte
    {
        Home,
        Mobile,
        Work,
        Office,
        Secretary
    }

}
