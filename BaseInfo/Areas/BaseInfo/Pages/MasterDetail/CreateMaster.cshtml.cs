using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace BaseInfo.Areas.BaseInfo.Pages.MasterDetail
{
    public class CreateMasterModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.BaseInfo.MasterDetail MasterDetailModel { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet();
            }

            string result = ApiExtension
                .PostAsync<string, Model.Entity.BaseInfo.MasterDetail>(
                    GlobalParameter.ApiBaseAddress, "/api/MasterDetail/CreateMaster",
                    MasterDetailModel, HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("ListMaster");
            }

            ModelState.AddModelError("", result);
            return OnGet();
        }
    }
}