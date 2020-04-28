using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Identity.Areas.Identity.Pages.Role
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.Role RoleModel { get; set; }

        public IActionResult OnGet(Guid softwareId)
        {
            RoleModel.SoftwareId = softwareId;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(RoleModel.SoftwareId);
            }

            var result = ApiExtension.PostAsync<string, Model.Entity.Identity.Role>(
                GlobalParameter.ApiBaseAddress, "/api/Role/Create", RoleModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List", new { softwareId = RoleModel.SoftwareId });
            }
            ModelState.AddModelError("", result);
            return OnGet(RoleModel.SoftwareId);
        }
    }
}
