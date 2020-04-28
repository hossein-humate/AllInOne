using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Identity.Areas.Identity.Pages.Permission
{
    public class ListModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid? SoftwareId { get; set; }

        public IEnumerable<Model.Entity.Application.Software> Softwares { get; set; }
        public IActionResult OnGet(Guid softwareId = default)
        {
            Softwares = ApiExtension.PostAsync<IEnumerable<Model.Entity.Application.Software>,Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Software/GetByUserId",
                HttpContext. Session.Get<Model.Entity.Identity.User>("CurrentUser").Id,
                HttpContext.Session.GetString("Token")).Result;
            SoftwareId = softwareId == default ? Softwares.FirstOrDefault()?.Id  : softwareId;
            return Page();
        }
    }
}
