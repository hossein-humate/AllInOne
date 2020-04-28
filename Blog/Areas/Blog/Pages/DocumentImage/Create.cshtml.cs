using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Blog.Areas.Blog.Pages.DocumentImage
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Blog.DocumentImage DocumentImageModel { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "انتخاب تصویر الزامی است")]
        public IFormFile FormFile { get; set; }
        public IActionResult OnGet(Guid documentId)
        {
            DocumentImageModel.DocumentId = documentId;
            return Page();
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("DocumentImageModel.Name");
            if (!ModelState.IsValid)
            {
                return OnGet(DocumentImageModel.DocumentId);
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
                    return OnGet(DocumentImageModel.DocumentId);
                }
                DocumentImageModel.Name = result;
            }
            result = ApiExtension.PostAsync<string, Model.Entity.Blog.DocumentImage>(
                GlobalParameter.ApiBaseAddress, "/api/DocumentImage/Create", DocumentImageModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List", new { documentId = DocumentImageModel.DocumentId });
            }
            ModelState.AddModelError("", result);
            return OnGet(DocumentImageModel.DocumentId);
        }
    }
}
