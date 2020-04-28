using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Utility;

namespace BaseInfo.Areas.BaseInfo.Pages.MasterDetail
{
    public class ListMasterModel : PageModel
    {
        public IEnumerable<Model.Entity.BaseInfo.MasterDetail> MasterModel { get; set; }
        public IActionResult OnGet()
        {
            MasterModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.BaseInfo.MasterDetail>>(
                GlobalParameter.ApiBaseAddress, "api/MasterDetail/GetAllMaster",
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }
    }
}