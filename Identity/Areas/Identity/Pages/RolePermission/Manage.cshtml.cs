using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DTO.PageModel;
using Model.Entity.Application;
using Utility;

namespace Identity.Areas.Identity.Pages.RolePermission
{
    public class ManageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "حداقل یکی از شاخه ها را انتخاب کنید")]
        public string CheckedItems { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "انتخاب گروه الزامی است")]
        public Guid RoleId { get; set; }

        public IEnumerable<Model.Entity.Identity.Role> Roles { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "انتخاب نرم افزار الزامی است")]
        public Guid SoftwareId { get; set; }

        public IEnumerable<Software> Softwares { get; set; }

        public IActionResult OnGet(Guid softwareId = default, Guid roleId = default)
        {
            if (RoleId == Guid.Empty) RoleId = roleId;
            Softwares = ApiExtension.PostAsync<IEnumerable<Software>, Guid>(
                 GlobalParameter.ApiBaseAddress, "/api/Software/GetByUserId",
                 HttpContext.Session.Get<Model.Entity.Identity.User>("CurrentUser").Id,
                 HttpContext.Session.GetString("Token")).Result;
            Roles = ApiExtension.GetAsync<IEnumerable<Model.Entity.Identity.Role>>(GlobalParameter.ApiBaseAddress,
                "/api/Role/GetBySoftwareId", HttpContext.Session.GetString("Token"),
                new Dictionary<string, string>
                {
                    {"SoftwareId",softwareId.ToString() }
                }).Result;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelState["CheckedItems"].Errors[0].ErrorMessage);
                return OnGet(SoftwareId,RoleId);
            }

            var result = ApiExtension.PostAsync<string, RequestParameters>(GlobalParameter.ApiBaseAddress,
                "/api/RolePermission/Create", new RequestParameters
                {
                    Param1 = RoleId,
                    Param2 = CheckedItems
                }, HttpContext.Session.GetString("Token")).Result;
            if (string.IsNullOrWhiteSpace(result))
            {
                return OnGet(SoftwareId, RoleId);
            }
            ModelState.AddModelError("", result);
            return OnGet(SoftwareId, RoleId);
        }
    }
}
