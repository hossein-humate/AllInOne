using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Identity.Areas.Identity.Pages.Address
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Identity.Address> AddressesModel { get; set; }
        public IActionResult OnGet()
        {
            AddressesModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Identity.Address>>(
                GlobalParameter.ApiBaseAddress, "api/Address/GetAll",
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }
    }
}
