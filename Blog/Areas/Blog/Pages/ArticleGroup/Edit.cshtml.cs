using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Utility;

namespace Blog.Areas.Blog.Pages.ArticleGroup
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Blog.ArticleGroup ArticleGroupModel { get; set; }
        public IEnumerable<SelectListItem> Parents { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile FormFile { get; set; }
        public IActionResult OnGet(Guid id)
        {
            Parents = ApiExtension.GetAsync<IEnumerable<SelectListItem>>(
                GlobalParameter.ApiBaseAddress, "/api/ArticleGroup/GetForSelectList",
                HttpContext.Session.GetString("Token"),
                new Dictionary<string, string>
                {
                    {"ArticleGroupId",id.ToString()}
                }).Result;

            ArticleGroupModel = ApiExtension.PostAsync<Model.Entity.Blog.ArticleGroup, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/ArticleGroup/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(ArticleGroupModel.Id);
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
                    return OnGet(ArticleGroupModel.Id);
                }
                ArticleGroupModel.Image = result;
            }
            result = ApiExtension.PostAsync<string, Model.Entity.Blog.ArticleGroup>(
               GlobalParameter.ApiBaseAddress, "/api/ArticleGroup/Update", ArticleGroupModel,
               HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List");
            }
            ModelState.AddModelError("", result);
            return OnGet(ArticleGroupModel.Id);
        }
    }
}