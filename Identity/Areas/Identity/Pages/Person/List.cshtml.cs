using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Utility;

namespace Identity.Areas.Identity.Pages.Person
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Identity.Person> PersonsModel { get; set; }
        public IActionResult OnGet()
        {
            PersonsModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Identity.Person>>(
                GlobalParameter.ApiBaseAddress, "api/Person/GetAll",
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }
    }
}
