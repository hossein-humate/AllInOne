using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.Identity
{
    [Table(name: "Visitors", Schema = "Identity")]
    public class Visitor : BaseEntity
    {
        ~Visitor() { Dispose(true); }

        public string Ip { get; set; }

        public double ExecuteTime { get; set; }

        public string Browser { get; set; }

        public string Platform { get; set; }

        public string Device { get; set; }

        public string UserAgent { get; set; }

        public string UrlPath { get; set; }

        public bool IsOurUser { get; set; }

        public Guid UserId { get; set; }

        public string StatusCode { get; set; }
    }
}
