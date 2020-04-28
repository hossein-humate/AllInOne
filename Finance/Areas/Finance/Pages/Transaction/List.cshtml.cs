using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.Identity;
using Utility;

namespace Finance.Areas.Finance.Pages.Transaction
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Finance.Transaction> TransactionsModel { get; set; }

        public IActionResult OnGet()
        {
            TransactionsModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Finance.Transaction>>(
                              GlobalParameter.ApiBaseAddress, "/api/Transaction/GetByUserId",
                              HttpContext.Session.GetString("Token"),
                              new Dictionary<string, string>
                              {
                                 {"UserId",HttpContext.Session.Get<User>("CurrentUser").Id.ToString()}
                              }).Result;
            return Page();
        }
    }
}
