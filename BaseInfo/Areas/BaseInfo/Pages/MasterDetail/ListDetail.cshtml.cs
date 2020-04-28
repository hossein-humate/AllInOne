using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Utility;

namespace BaseInfo.Areas.BaseInfo.Pages.MasterDetail
{
    public class ListDetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public IEnumerable<Model.Entity.BaseInfo.MasterDetail> DetailsModel { get; set; }
        public Model.Entity.BaseInfo.MasterDetail MasterModel { get; set; }
        public IActionResult OnGet(Guid id)
        {
            DetailsModel = ApiExtension.PostAsync<IEnumerable<Model.Entity.BaseInfo.MasterDetail>,
                Guid>(GlobalParameter.ApiBaseAddress, "/api/MasterDetail/GetAllDetail", id,
                HttpContext.Session.GetString("Token")).Result;
            MasterModel = ApiExtension.PostAsync<Model.Entity.BaseInfo.MasterDetail,
                Guid>(GlobalParameter.ApiBaseAddress, "/api/MasterDetail/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }
    }
}