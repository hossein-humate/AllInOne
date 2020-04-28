using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utility;

namespace Blog.Areas.Blog.Pages.Document
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Blog.Document DocumentModel { get; set; }

        public IEnumerable<SelectListItem> Parents { get; set; }

        public IActionResult OnGet(Guid id)
        {
            Parents = ApiExtension.GetAsync<IEnumerable<SelectListItem>>(
                GlobalParameter.ApiBaseAddress, "/api/Document/GetForSelectList",
                HttpContext.Session.GetString("Token")).Result;

            DocumentModel = ApiExtension.PostAsync<Model.Entity.Blog.Document, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Document/GetById", id,
                HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(DocumentModel.Id);
            }

            var result = ApiExtension.PostAsync<string, Model.Entity.Blog.Document>(
                GlobalParameter.ApiBaseAddress, "/api/Document/Update", DocumentModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List");
            }
            ModelState.AddModelError("", result);
            return OnGet(DocumentModel.Id);
        }
    }
}
