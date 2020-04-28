using System;

namespace Model.DTO.General
{
    public static class LastRequest
    {
        public static string Ip { get; set; }
        public static string Path { get; set; }
        public static string Method { get; set; }
        public static string UserAgent { get; set; }
        public static DateTime DateTime { get; set; }
    }
}
