using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Identity.Areas.Identity.Pages.User
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.User UserModel { get; set; }
        public IActionResult OnGet()
        {
            UserModel = HttpContext.Session.Get<Model.Entity.Identity.User>("CurrentUser");
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet();
            }

            string result = ApiExtension
                .PostAsync<string, Model.Entity.Identity.User>(
                    GlobalParameter.ApiBaseAddress, "/api/User/UpdateBaseInfo", UserModel,
                    HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                UserModel = ApiExtension
                    .PostAsync<Model.Entity.Identity.User, string>(
                        GlobalParameter.ApiBaseAddress, "/api/User/GetByUsername",
                        UserModel.Username, HttpContext.Session.GetString("Token")).Result;
                UserModel.Password = "";
                UserModel.RePassword = "";
                UserModel.PasswordHash = null;
                UserModel.PasswordSalt = null;
                HttpContext.Session.Set("CurrentUser", UserModel);
                return RedirectToPage("Profile");
            }

            ModelState.AddModelError("", result);
            return OnGet();
        }
    }
}