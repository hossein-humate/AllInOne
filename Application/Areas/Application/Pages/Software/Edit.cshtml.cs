using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Utility;

namespace Application.Areas.Application.Pages.Software
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Application.Software SoftwareModel { get; set; }

        public IActionResult OnGet(Guid id)
        {
            SoftwareModel = ApiExtension.PostAsync<Model.Entity.Application.Software, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Software/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            if (SoftwareModel == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(SoftwareModel.Id);
            }
            try
            {
                var result = ApiExtension.PostAsync<string,
                    Model.Entity.Application.Software>(GlobalParameter.ApiBaseAddress,
                    "/api/Software/Update", SoftwareModel,
                    HttpContext.Session.GetString("Token")).Result;
                if (string.IsNullOrWhiteSpace(result))
                {
                    return RedirectToPage("List");
                }
                return OnGet(SoftwareModel.Id);
            }
            catch (Exception)
            {
                return BadRequest("خطا در هنگام ذخیره اطلاعات");
            }
        }


    }
}