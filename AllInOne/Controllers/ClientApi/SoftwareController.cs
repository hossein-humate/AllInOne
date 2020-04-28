using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace AllInOne.Controllers.ClientApi
{
    [Route("api/v1/[controller]")]
    public class SoftwareController : ApiBaseController
    {
        [HttpGet("GetSoftware")]
        public JsonResult GetSoftware()
        {
            var result = UnitOfWork.Softwares.GetById(Request.Headers["SoftwareId"].ToGuid());
            return new JsonResult(new
            {
                result.FaName,
                result.EnName,
                result.Methodology,
                result.ProgrammingLanguage,
                result.Description
            });
        }
    }
}