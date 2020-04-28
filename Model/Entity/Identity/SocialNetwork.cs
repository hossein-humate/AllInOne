using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "SocialNetworks", Schema = "Identity")]
    public class SocialNetwork : BaseEntity
    {
        ~SocialNetwork() { Dispose(true); }

        public Guid UserId { get; set; }

        [Display(Name = "نام کاربری شبکه اجتماعی")]
        public string Username { get; set; }

        [Display(Name = "نوع شبکه اجتماعی")]
        public SocialNetworkProvider Provider { get; set; }

    }
    public enum SocialNetworkProvider : byte
    {
        Facebook,
        Instagram,
        Twitter,
        YouTube,
        Telegram,
        Viber,
        WhatsApp,
        Imo,
        Soroush,
        LinkedIn,
        StackOverFlow,
        WeChat,
        Skype,
        SnapChat,
        Reddit,
        Pinterest
    }
}