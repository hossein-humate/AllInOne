using System;

namespace Utility
{
    public static class GlobalParameter
    {
        public static string ApiBaseAddress { get; set; }
        public static string Connection { get; set; }
        public static string CdnDomainUrl { get; set; }
        public static string CdnLocalPath { get; set; }

        #region Const

        public static Guid HumateSoftwareId = "D3E95300-7461-46B3-927C-EEA966286DAE".ToGuid();
        public static Guid HumatePublicRoleId = "0880A8E9-EBC3-476E-862B-6827F141D553".ToGuid();
        public static Guid BankMasterId = "F39B54B0-DE7F-4D3F-A6DD-EE73FF0A8F1F".ToGuid();
        public static Guid DealTypeMasterId = "4F701B16-FD78-4CBE-9084-C20B91DCE05C".ToGuid();
        public static Guid GetStartDocumentId = "86D3BD5A-9708-4841-8F96-947071F120CC".ToGuid();

        public static string PersonImagePath = "/UploadedFiles/Person/";
        public static string ArticleImagePath = "/UploadedFiles/ArticleImage/";
        public static string DocumentImagePath = "/UploadedFiles/DocumentImage/";
        #endregion
    }
}