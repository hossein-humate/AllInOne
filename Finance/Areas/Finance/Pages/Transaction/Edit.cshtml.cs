using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.BaseInfo;
using System;
using System.Collections.Generic;
using Utility;
using Utility.Helpers;

namespace Finance.Areas.Finance.Pages.Transaction
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Finance.Transaction TransactionModel { get; set; }
        public IEnumerable<MasterDetail> DealTypes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Date { get; set; }
        public IActionResult OnGet(Guid id)
        {
            DealTypes = ApiExtension.PostAsync<IEnumerable<MasterDetail>, Guid>(GlobalParameter.ApiBaseAddress,
                "/api/MasterDetail/GetAllDetail", GlobalParameter.DealTypeMasterId,
                HttpContext.Session.GetString("Token")).Result;
            TransactionModel = ApiExtension.PostAsync<Model.Entity.Finance.Transaction, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Transaction/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            Date = TransactionModel.Date != null ? TransactionModel.Date.Value.GetPersianDateTime() : "";
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(TransactionModel.Id);
            }
            if (!string.IsNullOrWhiteSpace(Date))
                TransactionModel.Date = Date.GetGregorianDateTime();
            var result = ApiExtension.PostAsync<string, Model.Entity.Finance.Transaction>(
                GlobalParameter.ApiBaseAddress, "/api/Transaction/Update", TransactionModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List");
            }
            ModelState.AddModelError("", result);
            return OnGet(TransactionModel.Id);
        }
    }
}
