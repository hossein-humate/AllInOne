using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers.Blog
{
    [Route("Html")]
    public class HtmlController : Controller
    {
        [HttpGet("ShowProfit")]
        public IActionResult ShowProfit()
        {
            return Content(System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),
                "Html/showProfit.html")), "text/html");
        }
    }
}