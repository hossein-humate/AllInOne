using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Utility;

namespace Blog.Areas.Blog.Pages.ArticleGroup
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Blog.ArticleGroup> ArticleGroupsModel { get; set; }

        public IActionResult OnGet()
        {
            ArticleGroupsModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Blog.ArticleGroup>>(
                              GlobalParameter.ApiBaseAddress, "/api/ArticleGroup/GetAll",
                              HttpContext.Session.GetString("Token")).Result;
            return Page();
        }
    }
}
