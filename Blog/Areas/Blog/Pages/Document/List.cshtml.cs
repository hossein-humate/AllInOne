using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Blog.Areas.Blog.Pages.Document
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Blog.Document> DocumentsModel { get; set; }

        public IActionResult OnGet()
        {
            DocumentsModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Blog.Document>>(
                              GlobalParameter.ApiBaseAddress, "/api/Document/GetAll",
                              HttpContext.Session.GetString("Token")).Result;
            return Page();
        }
    }
}
