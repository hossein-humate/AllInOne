using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "Addresses", Schema = "Identity")]
    public class Address : BaseEntity
    {
        ~Address(){Dispose(true);}
        public Guid UserId { get; set; }

        [Display(Name = "کشور")]
        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        [Display(Name = "استان")]
        public string State { get; set; }

        [Display(Name = "شهر")]
        [StringLength(50)]
        public string City { get; set; }

        [StringLength(10)]
        [Display(Name = "کد پستی")]
        public string PostalCode { get; set; }

        [Display(Name = "آدرس اصلی")]
        public bool Primary { get; set; }

        [Display(Name = "تایید شده")]
        public bool Confirmed { get; set; }

        [Display(Name = "طول جغرافیایی")]
        public bool Longitude { get; set; }

        [Display(Name = "عرض جغرافیایی")]
        public bool Latitude { get; set; }

        [Display(Name = "نوع آدرس")]
        [DefaultValue(0)]
        public AddressType Type { get; set; }

        public virtual Guid? CityAreaId { get; set; }

        public virtual User User { get; set; }
    }
    public enum AddressType : byte
    {
        Home,
        Work,
        Office,
    }
}
