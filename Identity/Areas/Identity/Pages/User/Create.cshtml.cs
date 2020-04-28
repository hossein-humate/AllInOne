using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Identity.Areas.Identity.Pages.User
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.User UserModel { get; set; }

        public IActionResult OnGet(Guid softwareId)
        {
            UserModel.SoftwareId = softwareId;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(UserModel.SoftwareId);
            }

            var result = ApiExtension.PostAsync<string, Model.Entity.Identity.User>(
                GlobalParameter.ApiBaseAddress, "/api/User/RegisterUser", UserModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List", new { softwareId = UserModel.SoftwareId });
            }
            ModelState.AddModelError("", result);
            return OnGet(UserModel.SoftwareId);
        }
    }
}
