using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DTO.PageModel;
using Utility;

namespace Identity.Areas.Identity.Pages.UserSoftware
{
    public class ManageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "حداقل یکی از شاخه ها را انتخاب کنید")]
        public string CheckedItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.User UserModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid SoftwareId { get; set; }
        public IActionResult OnGet(Guid userId,Guid softwareId=default)
        {
            if (SoftwareId == Guid.Empty) SoftwareId = softwareId;
            UserModel = ApiExtension.PostAsync<Model.Entity.Identity.User, Guid>(GlobalParameter.ApiBaseAddress,
                   "/api/User/GetByIdWithPerson", userId, HttpContext.Session.GetString("Token")).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("UserModel.Username");
            ModelState.Remove("UserModel.RePassword");
            ModelState.Remove("UserModel.Password");
            ModelState.Remove("UserModel.Mobile");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelState["CheckedItems"].Errors[0].ErrorMessage);
                return OnGet(UserModel.Id);
            }

            var result = ApiExtension.PostAsync<string, RequestParameters>(GlobalParameter.ApiBaseAddress,
                "/api/UserSoftware/CreateRange", new RequestParameters
                {
                    Param1 = UserModel.Id,
                    Param2 = CheckedItems
                }, HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return OnGet(UserModel.Id);
            }
            ModelState.AddModelError("", result);
            return OnGet(UserModel.Id);
        }
    }
}
