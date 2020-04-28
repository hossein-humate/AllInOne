using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Identity.Areas.Identity.Pages.Person
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.Person PersonModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile FormFile { get; set; }
        public IActionResult OnGet()
        {
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
                   GlobalParameter.ApiBaseAddress, "/api/Person/SaveImageFile",
                   FormFile, HttpContext.Session.GetString("Token")).Result;
                if (string.IsNullOrWhiteSpace(result))
                {
                    ModelState.AddModelError("", "ذخیره فایل با مشکل مواجه شد.");
                    return OnGet();
                }
                PersonModel.PicturePath = result;
            }

            result = ApiExtension.PostAsync<string, Model.Entity.Identity.Person>(
                GlobalParameter.ApiBaseAddress, "/api/Person/Create", PersonModel,
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
