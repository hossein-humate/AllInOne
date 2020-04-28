using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Utility;

namespace Blog.Areas.Blog.Pages.ArticleGroup
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Blog.ArticleGroup ArticleGroupModel { get; set; }
        public IEnumerable<SelectListItem> Parents { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile FormFile { get; set; }
        public IActionResult OnGet()
        {
            Parents = ApiExtension.GetAsync<IEnumerable<SelectListItem>>(
                GlobalParameter.ApiBaseAddress, "/api/ArticleGroup/GetForSelectList",
                HttpContext.Session.GetString("Token"),
                new Dictionary<string, string>
                {
                    {"ArticleGroupId",ArticleGroupModel.Id.ToString()}
                }).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet();
            }
            string result;
            if (FormFile != null)
            {
                result = ApiExtension.PostFormFileAsync(
                    GlobalParameter.ApiBaseAddress, "/api/ArticleGroup/SaveImageFile",
                    FormFile, HttpContext.Session.GetString("Token")).Result;
                if (string.IsNullOrWhiteSpace(result))
                {
                    ModelState.AddModelError("", "ذخیره فایل با مشکل مواجه شد.");
                    return OnGet();
                }
                ArticleGroupModel.Image = result;
            }
            result = ApiExtension.PostAsync<string, Model.Entity.Blog.ArticleGroup>(
               GlobalParameter.ApiBaseAddress, "/api/ArticleGroup/Create", ArticleGroupModel,
               HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List");
            }
            ModelState.AddModelError("", result);
            return OnGet();
        }
    }
}
