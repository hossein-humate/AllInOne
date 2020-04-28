using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace BaseInfo.Areas.BaseInfo.Pages.MasterDetail
{
    public class EditMasterModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.BaseInfo.MasterDetail MasterDetailModel { get; set; }
        public IActionResult OnGet(Guid id)
        {
            MasterDetailModel = ApiExtension
                .PostAsync<Model.Entity.BaseInfo.MasterDetail, Guid>(
                    GlobalParameter.ApiBaseAddress, "/api/MasterDetail/GetById",
                    id, HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(MasterDetailModel.MasterId);
            }

            string result = ApiExtension
                .PostAsync<string, Model.Entity.BaseInfo.MasterDetail>(
                    GlobalParameter.ApiBaseAddress, "/api/MasterDetail/UpdateMaster",
                    MasterDetailModel, HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("ListMaster");
            }

            ModelState.AddModelError("", result);
            return OnGet(MasterDetailModel.MasterId);
        }
    }
}