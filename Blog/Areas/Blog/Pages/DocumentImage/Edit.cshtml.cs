using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Blog.Areas.Blog.Pages.DocumentImage
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Blog.DocumentImage DocumentImageModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile FormFile { get; set; }

        public IActionResult OnGet(Guid id)
        {
            DocumentImageModel = ApiExtension.PostAsync<Model.Entity.Blog.DocumentImage, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/DocumentImage/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(DocumentImageModel.Id);
            }

            string result;
            if (FormFile != null)
            {
                result = ApiExtension.PostFormFileAsync(
                    GlobalParameter.ApiBaseAddress, "/api/DocumentImage/SaveImageFile",
                    FormFile, HttpContext.Session.GetString("Token")).Result;
                if (string.IsNullOrWhiteSpace(result))
                {
                    ModelState.AddModelError("", "ذخیره فایل با مشکل مواجه شد.");
                    return OnGet(DocumentImageModel.Id);
                }
                DocumentImageModel.Name = result;
            }
            result = ApiExtension.PostAsync<string, Model.Entity.Blog.DocumentImage>(
                GlobalParameter.ApiBaseAddress, "/api/DocumentImage/Update", DocumentImageModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List", new { documentId = DocumentImageModel.DocumentId });
            }
            ModelState.AddModelError("", result);
            return OnGet(DocumentImageModel.Id);
        }
    }
}
