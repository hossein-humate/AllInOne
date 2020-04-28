using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Utility;

namespace Blog.Areas.Blog.Pages.ArticleImage
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Blog.ArticleImage ArticleImageModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile FormFile { get; set; }

        public IActionResult OnGet(Guid id)
        {
            ArticleImageModel = ApiExtension.PostAsync<Model.Entity.Blog.ArticleImage, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/ArticleImage/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(ArticleImageModel.Id);
            }

            string result;
            if (FormFile != null)
            {
                result = ApiExtension.PostFormFileAsync(
                    GlobalParameter.ApiBaseAddress, "/api/ArticleImage/SaveImageFile",
                    FormFile, HttpContext.Session.GetString("Token")).Result;
                if (string.IsNullOrWhiteSpace(result))
                {
                    ModelState.AddModelError("", "ذخیره فایل با مشکل مواجه شد.");
                    return OnGet(ArticleImageModel.Id);
                }
                ArticleImageModel.Name = result;
            }
            result = ApiExtension.PostAsync<string, Model.Entity.Blog.ArticleImage>(
                GlobalParameter.ApiBaseAddress, "/api/ArticleImage/Update", ArticleImageModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List", new { articleId = ArticleImageModel.ArticleId });
            }
            ModelState.AddModelError("", result);
            return OnGet(ArticleImageModel.Id);
        }
    }
}
