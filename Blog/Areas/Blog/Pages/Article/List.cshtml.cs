using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Utility;

namespace Blog.Areas.Blog.Pages.Article
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Blog.Article> ArticlesModel { get; set; }

        public IActionResult OnGet()
        {
            ArticlesModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Blog.Article>>(
                              GlobalParameter.ApiBaseAddress, "/api/Article/GetAll",
                              HttpContext.Session.GetString("Token")).Result;
            return Page();
        }
    }
}
