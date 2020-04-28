namespace Model.DTO.General
{
    public class ApiResult
    {
        public object Value { get; set; }

        public StatusCodeType StatusCode { get; set; }

        public string ErrorMessage { get; set; }
    }

    public enum StatusCodeType
    {
        Success,
        Warning,
        ErrorHasThrown,
        TimeOut
    }
}
