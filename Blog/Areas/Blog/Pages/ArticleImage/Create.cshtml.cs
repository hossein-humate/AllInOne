using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using Utility;

namespace Blog.Areas.Blog.Pages.ArticleImage
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Blog.ArticleImage ArticleImageModel { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "انتخاب تصویر الزامی است")]
        public IFormFile FormFile { get; set; }
        public IActionResult OnGet(Guid articleId)
        {
            ArticleImageModel.ArticleId = articleId;
            return Page();
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("ArticleImageModel.Name");
            if (!ModelState.IsValid)
            {
                return OnGet(ArticleImageModel.ArticleId);
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
                    return OnGet(ArticleImageModel.ArticleId);
                }
                ArticleImageModel.Name = result;
            }
            result = ApiExtension.PostAsync<string, Model.Entity.Blog.ArticleImage>(
                GlobalParameter.ApiBaseAddress, "/api/ArticleImage/Create", ArticleImageModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List", new { articleId = ArticleImageModel.ArticleId });
            }
            ModelState.AddModelError("", result);
            return OnGet(ArticleImageModel.ArticleId);
        }
    }
}
