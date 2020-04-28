using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity.ClientApi
{
    [Table(name: "Requests", Schema = "ClientApi")]
    public class Request : BaseEntity
    {
        ~Request() { Dispose(true); }

        public Guid? SoftwareId { get; set; }

        public string Ip { get; set; }

        public float? RespondTime { get; set; }

        public string UserAgent { get; set; }

        public string ApiKey { get; set; }

        public string RequestPath { get; set; }

        public string StatusCode { get; set; }
    }
}
