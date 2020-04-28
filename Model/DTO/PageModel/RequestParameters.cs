namespace Model.DTO.PageModel
{
    public class RequestParameters : BaseDto
    {
        ~RequestParameters() { Dispose(true); }

        public object Param1 { get; set; }
        public object Param2 { get; set; }
        public object Param3 { get; set; }
    }
}
