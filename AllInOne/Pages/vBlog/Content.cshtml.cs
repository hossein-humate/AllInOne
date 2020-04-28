using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.Blog;
using Utility;

namespace AllInOne.Pages.vBlog
{
    public class ContentModel : PageModel
    {
        public Article ArticleModel { get; set; }
        public IActionResult OnGet(Guid articleId)
        {
            ArticleModel = ApiExtension.GetAsync<Article>(GlobalParameter.ApiBaseAddress,
                "/api/article/GetWithGroupAndImage", headers:
                new Dictionary<string, string>{
                    {"Id", articleId.ToString()}}).Result;
            if (ArticleModel == null) 
                return Redirect("/vBlog/ArticleGroup");
            return Page();
        }
    }
}