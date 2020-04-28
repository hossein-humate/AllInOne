using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Utility;

namespace Blog.Areas.Blog.Pages.ArticleImage
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Blog.ArticleImage> ArticleImagesModel { get; set; }
        public Model.Entity.Blog.Article Article { get; set; }
        public IActionResult OnGet(Guid articleId)
        {
            Article = ApiExtension.PostAsync<Model.Entity.Blog.Article, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Article/GetById", articleId,
                HttpContext.Session.GetString("Token")).Result;
            ArticleImagesModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Blog.ArticleImage>>(
                              GlobalParameter.ApiBaseAddress, "/api/ArticleImage/GetByArticleId",
                              HttpContext.Session.GetString("Token"),
                              new Dictionary<string, string>{
                                  {"ArticleId",articleId.ToString()}
                              }).Result;
            return Page();
        }
    }
}
