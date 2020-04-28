using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DTO.PageModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.Entity.Application;
using Utility;

namespace Identity.Areas.Identity.Pages.UserRole
{
    public class ManageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "حداقل یکی از شاخه ها را انتخاب کنید")]
        public string CheckedItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public Model.Entity.Identity.User UserModel { get; set; }


        [BindProperty(SupportsGet = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "انتخاب نرم افزار الزامی است")]
        public Guid SoftwareId { get; set; }

        public IEnumerable<Software> Softwares { get; set; }

        public IActionResult OnGet(Guid userId, Guid softwareId = default)
        {
            if (SoftwareId == Guid.Empty) SoftwareId = softwareId;
            Softwares = ApiExtension.PostAsync<IEnumerable<Software>, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Software/GetByUserId",userId,
                HttpContext.Session.GetString("Token")).Result;
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
                "/api/UserRole/Create", new RequestParameters
                {
                    Param1 = UserModel.Id,
                    Param2 = CheckedItems,
                    Param3 = SoftwareId
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
