using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace AllInOne.Pages.Home
{
    public class RegisterModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.User UserModel { get; set; }
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
            UserModel.SoftwareId = GlobalParameter.HumateSoftwareId;
            UserModel.RegisterDate = DateTime.Now;
            UserModel.RegisterIp = HttpContext.Connection.RemoteIpAddress.ToString();
            string token = ApiExtension
                .PostAsync<string, Model.Entity.Identity.User>(
                    GlobalParameter.ApiBaseAddress, "/api/User/RegisterAndLogin", UserModel).Result;
            if (!string.IsNullOrWhiteSpace(token))
            {
                UserModel = ApiExtension
                    .PostAsync<Model.Entity.Identity.User, string>(
                        GlobalParameter.ApiBaseAddress, "/api/User/GetByUsername",
                        UserModel.Username, token).Result;
                UserModel.Password = "";
                UserModel.RePassword = "";
                UserModel.PasswordHash = null;
                UserModel.PasswordSalt = null;
                HttpContext.Session.Set("CurrentUser", UserModel);
                HttpContext.Session.SetString("Token", token);
                return Redirect("/");
            }

            ModelState.AddModelError("", token);
            return OnGet();
        }
    }
}