using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Utility;
using Model.Entity.Blog;

namespace AllInOne.Pages.Docs
{
    public class ExploreModel : PageModel
    {
        public Document DocumentModel { get; set; }
        //public IEnumerable<Document> DocumentsModel { get; set; }
        public IActionResult OnGet(Guid documentId = default)
        {
            DocumentModel = ApiExtension.GetAsync<Document>(GlobalParameter.ApiBaseAddress,
                "/api/Document/GetByIdWithImageChildrens", headers: new Dictionary<string, string>
                {
                        {"Id",documentId == default ?
                            GlobalParameter.GetStartDocumentId.ToString() : documentId.ToString() }
                }).Result;
            //DocumentsModel = ApiExtension.GetAsync<IEnumerable<Document>>(GlobalParameter.ApiBaseAddress,
            //    "/api/Document/GetAllWithChildrens").Result;
            return Page();
        }
    }
}
