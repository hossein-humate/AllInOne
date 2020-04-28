using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.Blog;
using Utility;

namespace AllInOne.Pages.vBlog
{
    public class ArticleModel : PageModel
    {
        public IEnumerable<Article> ArticlesModel { get; set; }
        public Guid ArticleGroupId { get; set; }
        public IActionResult OnGet(Guid articleGroupId)
        {
            ArticleGroupId = articleGroupId;
            ArticlesModel = ApiExtension.GetAsync<IEnumerable<Article>>(GlobalParameter.ApiBaseAddress,
                "/api/article/GetAllWithGroupAndImage", headers: new Dictionary<string, string>
                {
                    {"ArticleGroupId", articleGroupId.ToString()}
                }).Result;
            return Page();
        }
    }
}