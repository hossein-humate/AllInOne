using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace Blog.Areas.Blog.Pages.DocumentImage
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Blog.DocumentImage> DocumentImagesModel { get; set; }
        public Model.Entity.Blog.Document Document { get; set; }
        public IActionResult OnGet(Guid documentId)
        {
            Document = ApiExtension.PostAsync<Model.Entity.Blog.Document, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Document/GetById", documentId,
                HttpContext.Session.GetString("Token")).Result;
            DocumentImagesModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Blog.DocumentImage>>(
                GlobalParameter.ApiBaseAddress, "/api/DocumentImage/GetByDocumentId",
                HttpContext.Session.GetString("Token"),
                new Dictionary<string, string>{
                    {"DocumentId",documentId.ToString()}
                }).Result;
            return Page();
        }
    }
}
