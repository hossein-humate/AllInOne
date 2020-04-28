using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Identity.Areas.Identity.Pages.Permission
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.Permission PermissionModel { get; set; }

        public Model.Entity.Identity.Permission ParentPermission { get; set; }
        public IActionResult OnGet(string parentId)
        {
            ParentPermission = ApiExtension.PostAsync<Model.Entity.Identity.Permission, string>(
                GlobalParameter.ApiBaseAddress, "/api/Permission/GetById", parentId,
                HttpContext.Session.GetString("Token")).Result;
            PermissionModel.ParentId = parentId.ToGuid();
            PermissionModel.SoftwareId = ParentPermission.SoftwareId;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(PermissionModel.ParentId.ToString());
            }

            var result = ApiExtension.PostAsync<string, Model.Entity.Identity.Permission>(
                GlobalParameter.ApiBaseAddress, "/api/Permission/Create", PermissionModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List", new { softwareId = PermissionModel.SoftwareId });
            }
            ModelState.AddModelError("", result);
            return OnGet(PermissionModel.ParentId.ToString());
        }
    }
}
