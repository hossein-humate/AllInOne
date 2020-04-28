using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Identity.Areas.Identity.Pages.Person
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.Person PersonModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public IFormFile FormFile { get; set; }
        public IActionResult OnGet(Guid id)
        {
            PersonModel = ApiExtension.PostAsync<Model.Entity.Identity.Person, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Person/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(PersonModel.Id);
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
                    return OnGet(PersonModel.Id);
                }
                PersonModel.PicturePath = result;
            }

            result = ApiExtension.PostAsync<string, Model.Entity.Identity.Person>(
                GlobalParameter.ApiBaseAddress, "/api/Person/Update", PersonModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                var tempUser = HttpContext.Session.Get<Model.Entity.Identity.User>("CurrentUser");
                tempUser.Person = PersonModel;
                HttpContext.Session.Set("CurrentUser", tempUser);
                return RedirectToPage("List");
            }
            ModelState.AddModelError("", result);
            return OnGet(PersonModel.Id);
        }
    }
}
