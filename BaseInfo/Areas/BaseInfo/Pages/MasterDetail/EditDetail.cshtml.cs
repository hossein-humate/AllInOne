using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Utility;

namespace BaseInfo.Areas.BaseInfo.Pages.MasterDetail
{
    public class EditDetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.BaseInfo.MasterDetail DetailModel { get; set; }
        public string MasterFaName { get; set; }
        public IActionResult OnGet(Guid id)
        {
            DetailModel = ApiExtension.PostAsync<Model.Entity.BaseInfo.MasterDetail,
                Guid>(GlobalParameter.ApiBaseAddress, "/api/MasterDetail/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            MasterFaName = ApiExtension.PostAsync<Model.Entity.BaseInfo.MasterDetail,
                Guid>(GlobalParameter.ApiBaseAddress, "/api/MasterDetail/GetById",
                DetailModel.MasterId, HttpContext.Session.GetString("Token")).Result.FaName;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(DetailModel.MasterId);
            }
            string result = ApiExtension
                .PostAsync<string, Model.Entity.BaseInfo.MasterDetail>(
                    GlobalParameter.ApiBaseAddress, "/api/MasterDetail/UpdateDetail",
                    DetailModel, HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("ListDetail", new { id = DetailModel.MasterId });
            }

            ModelState.AddModelError("", result);
            return OnGet(DetailModel.MasterId);
        }
    }
}