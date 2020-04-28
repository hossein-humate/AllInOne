using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.BaseInfo;
using Model.Entity.Identity;
using Utility;

namespace Finance.Areas.Finance.Pages.Account
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Finance.Account AccountModel { get; set; }

        public IEnumerable<MasterDetail> Banks { get; set; }
        public IActionResult OnGet()
        {
            Banks = ApiExtension.PostAsync<IEnumerable<MasterDetail>, Guid>(GlobalParameter.ApiBaseAddress,
                "/api/MasterDetail/GetAllDetail", GlobalParameter.BankMasterId,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet();
            }

            AccountModel.CardNumber = AccountModel.CardNumber.Replace("-", "");
            AccountModel.UserId = HttpContext.Session.Get<User>("CurrentUser").Id;
            var result = ApiExtension.PostAsync<string, Model.Entity.Finance.Account>(
                GlobalParameter.ApiBaseAddress, "/api/Account/Create", AccountModel,
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
