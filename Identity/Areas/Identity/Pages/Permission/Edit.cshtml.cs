using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Identity.Areas.Identity.Pages.Permission
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.Permission PermissionModel { get; set; }

        public IActionResult OnGet(Guid id)
        {
            PermissionModel = ApiExtension.PostAsync<Model.Entity.Identity.Permission, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Permission/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(PermissionModel.Id);
            }
            var result = ApiExtension.PostAsync<string, Model.Entity.Identity.Permission>(
                GlobalParameter.ApiBaseAddress, "/api/Permission/Update", PermissionModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List", new { softwareId = PermissionModel.SoftwareId });
            }
            ModelState.AddModelError("", result);
            return OnGet(PermissionModel.Id);
        }
    }
}
