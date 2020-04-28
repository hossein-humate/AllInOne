using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Utility;

namespace Blog.Areas.Blog.Pages.Article
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Blog.Article ArticleModel { get; set; }

        public IEnumerable<SelectListItem> ArticleGroups { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile FormFile { get; set; }

        public IActionResult OnGet(Guid id)
        {
            ArticleGroups = ApiExtension.GetAsync<IEnumerable<SelectListItem>>(
                GlobalParameter.ApiBaseAddress, "/api/ArticleGroup/GetForSelectList",
                HttpContext.Session.GetString("Token"),
                new Dictionary<string, string>
                {
                    {"ArticleGroupId",Guid.Empty.ToString()}
                }).Result;

            ArticleModel = ApiExtension.PostAsync<Model.Entity.Blog.Article, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Article/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(ArticleModel.Id);
            }

            string result;
            if (FormFile != null)
            {
                result = ApiExtension.PostFormFileAsync(
                    GlobalParameter.ApiBaseAddress, "/api/Article/SaveImageFile",
                    FormFile, HttpContext.Session.GetString("Token")).Result;
                if (string.IsNullOrWhiteSpace(result))
                {
                    ModelState.AddModelError("", "ذخیره فایل با مشکل مواجه شد.");
                    return OnGet(ArticleModel.Id);
                }
                ArticleModel.Image = result;
            }
            result = ApiExtension.PostAsync<string, Model.Entity.Blog.Article>(
                GlobalParameter.ApiBaseAddress, "/api/Article/Update", ArticleModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List");
            }
            ModelState.AddModelError("", result);
            return OnGet(ArticleModel.Id);
        }
    }
}
