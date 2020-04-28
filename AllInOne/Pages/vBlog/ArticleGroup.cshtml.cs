using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.Blog;
using Utility;

namespace AllInOne.Pages.vBlog
{
    public class ArticleGroupModel : PageModel
    {
        public IEnumerable<ArticleGroup> ArticleGroupsModel { get; set; }
        public IActionResult OnGet()
        {
            ArticleGroupsModel = ApiExtension.GetAsync<IEnumerable<ArticleGroup>>(GlobalParameter.ApiBaseAddress,
                "/api/ArticleGroup/GetAllWithArticleAndChilds").Result;
            return Page();
        }
    }
}