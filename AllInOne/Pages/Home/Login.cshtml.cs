using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Model.Entity.Identity;
using Utility;

namespace AllInOne.Pages.Home
{
    public class LoginModel : PageModel
    {
        private readonly ILogger _logger;

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)] public User UserModel { get; set; }

        public IActionResult OnGet()
        {
            _logger.LogInformation("Hello This is Login Page OnGet");
            HttpContext.Session.Set("CurrentUser", "");
            HttpContext.Session.SetString("Token", "");
            return Page();
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation("Hello This is Login Page OnPost");
            ModelState.Remove("UserModel.Mobile");
            ModelState.Remove("UserModel.RePassword");
            if (ModelState.IsValid)
            {
                UserModel.LastLoginIp = HttpContext.Connection.RemoteIpAddress.ToString();
                UserModel.LastLoginDate = DateTime.Now;
                var result = ApiExtension.PostAsync<string, User>(
                    GlobalParameter.ApiBaseAddress, "/api/User/LoginUser", UserModel).Result;
                if (!string.IsNullOrWhiteSpace(result))
                {
                    var user = ApiExtension.PostAsync<User, string>(
                        GlobalParameter.ApiBaseAddress, "/api/User/GetByUsername",
                        UserModel.Username, result).Result;
                    user.Password = "";
                    user.PasswordHash = null;
                    user.PasswordSalt = null;
                    HttpContext.Session.Set("CurrentUser", user);
                    HttpContext.Session.SetString("Token", result);
                    return Redirect("/Identity/User/Profile");
                }
                ModelState.AddModelError("", "نام کاربری یا گذرواژه اشتباه است!");
            }

            return Page();
        }
    }
}