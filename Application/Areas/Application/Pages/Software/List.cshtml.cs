using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Application.Areas.Application.Pages.Software
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Application.Software> SoftwaresModel { get; set; }
        public IActionResult OnGet()
        {
            SoftwaresModel = ApiExtension.PostAsync<IEnumerable<Model.Entity.Application.Software>, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Software/GetByUserId",
                HttpContext.Session.Get<Model.Entity.Identity.User>("CurrentUser").Id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }
    }
}
