using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTO.PageModel;
using Utility;
using Utility.Helpers;

namespace Application.Areas.Application.Pages.Software
{
    public class CreateApiKeyModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Application.Software SoftwareModel { get; set; }

        public IActionResult OnGet(Guid id)
        {
            SoftwareModel = ApiExtension.PostAsync<Model.Entity.Application.Software, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Software/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }
    }
}
