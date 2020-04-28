using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.Identity;
using System.Collections.Generic;
using Utility;

namespace Finance.Areas.Finance.Pages.Account
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Finance.Account> AccountsModel { get; set; }

        public IActionResult OnGet()
        {
            AccountsModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Finance.Account>>(
                              GlobalParameter.ApiBaseAddress, "/api/Account/GetByUserId",
                              HttpContext.Session.GetString("Token"),
                              new Dictionary<string, string>
                              {
                                 {"UserId",HttpContext.Session.Get<User>("CurrentUser").Id.ToString()}
                              }).Result;
            return Page();
        }
    }
}
