using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.BaseInfo;
using Utility;

namespace Finance.Areas.Finance.Pages.Account
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Finance.Account AccountModel { get; set; }
        public IEnumerable<MasterDetail> Banks { get; set; }
        public IActionResult OnGet(Guid id)
        {
            Banks = ApiExtension.PostAsync<IEnumerable<MasterDetail>, Guid>(GlobalParameter.ApiBaseAddress,
                "/api/MasterDetail/GetAllDetail", GlobalParameter.BankMasterId,
                HttpContext.Session.GetString("Token")).Result;

            AccountModel = ApiExtension.PostAsync<Model.Entity.Finance.Account, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Account/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(AccountModel.Id);
            }
            AccountModel.CardNumber = AccountModel.CardNumber.Replace("-", "");
            var result = ApiExtension.PostAsync<string, Model.Entity.Finance.Account>(
                GlobalParameter.ApiBaseAddress, "/api/Account/Update", AccountModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List");
            }
            ModelState.AddModelError("", result);
            return OnGet(AccountModel.Id);
        }
    }
}
