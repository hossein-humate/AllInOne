using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Utility;

namespace Blog.Areas.Blog.Pages.Document
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Model.Entity.Blog.Document DocumentModel { get; set; }

        public IEnumerable<SelectListItem> Parents { get; set; }
        public IActionResult OnGet()
        {
            Parents = ApiExtension.GetAsync<IEnumerable<SelectListItem>>(
              GlobalParameter.ApiBaseAddress, "/api/Document/GetForSelectList",
              HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return OnGet();
            }
            var result = ApiExtension.PostAsync<string, Model.Entity.Blog.Document>(
                GlobalParameter.ApiBaseAddress, "/api/Document/Create", DocumentModel,
                HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return RedirectToPage("List");
            }
            ModelState.AddModelError("", result);
            return OnGet();
        }
    }
}
