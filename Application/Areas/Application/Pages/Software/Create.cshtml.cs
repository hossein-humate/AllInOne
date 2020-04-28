using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Entity.Identity;
using Utility;

namespace Application.Areas.Application.Pages.Software
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Application.Software SoftwareModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet();
            }

            try
            {
                SoftwareModel.OwnerId = HttpContext.Session.Get<User>("CurrentUser").Id;
                var result = await ApiExtension.PostAsync<string, Model.Entity.Application.Software>(
                    GlobalParameter.ApiBaseAddress,"/api/Software/Create", SoftwareModel, 
                    HttpContext.Session.GetString("Token"),
                    new Dictionary<string, string>
                    {
                        { "UserId",HttpContext.Session.Get<User>("CurrentUser").Id.ToString()}
                    });
                if (string.IsNullOrWhiteSpace(result))
                {
                    return RedirectToPage("List");
                }
                ModelState.AddModelError("", result);
                return Page();
            }
            catch (Exception)
            {
                return BadRequest("خطا در هنگام ذخیره اطلاعات");
            }
        }
    }
}