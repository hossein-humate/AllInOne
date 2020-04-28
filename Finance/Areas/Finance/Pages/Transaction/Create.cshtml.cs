using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Entity.BaseInfo;
using Model.Entity.Identity;
using Utility;
using Utility.Helpers;

namespace Finance.Areas.Finance.Pages.Transaction
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Finance.Transaction TransactionModel { get; set; }

        public IEnumerable<MasterDetail> DealTypes { get; set; }
        public IEnumerable<SelectListItem> Accounts { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Date { get; set; }
        public IActionResult OnGet()
        {
            DealTypes = ApiExtension.PostAsync<IEnumerable<MasterDetail>, Guid>(GlobalParameter.ApiBaseAddress,
                "/api/MasterDetail/GetAllDetail", GlobalParameter.DealTypeMasterId,
                HttpContext.Session.GetString("Token")).Result;
            Accounts = ApiExtension.GetAsync<IEnumerable<SelectListItem>>(
                GlobalParameter.ApiBaseAddress, "/api/Account/GetForSelectListByUserId",
                HttpContext.Session.GetString("Token"),
                new Dictionary<string, string>
                {
                    {"UserId",HttpContext.Session.Get<User>("CurrentUser").Id.ToString()}
                }).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet();
            }
            if (!string.IsNullOrWhiteSpace(Date))
                TransactionModel.Date = Date.GetGregorianDateTime();
            var result = ApiExtension.PostAsync<string, Model.Entity.Finance.Transaction>(
                GlobalParameter.ApiBaseAddress, "/api/Transaction/Create", TransactionModel,
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
