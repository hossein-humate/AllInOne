﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entity.Application;
using Utility;

namespace Identity.Areas.Identity.Pages.Role
{
    public class ListModel : PageModel
    {
        public IEnumerable<Model.Entity.Identity.Role> RolesModel { get; set; }
        public IEnumerable<Software> Softwares { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "انتخاب نرم افزار الزامی است")]
        public Guid SoftwareId { get; set; }

        public IActionResult OnGet(Guid softwareId = default)
        {
            Softwares = ApiExtension.PostAsync<IEnumerable<Software>, Guid>(
                GlobalParameter.ApiBaseAddress, "/api/Software/GetByUserId",
                HttpContext.Session.Get<Model.Entity.Identity.User>("CurrentUser").Id,
                HttpContext.Session.GetString("Token")).Result;
            if (!Softwares.Any())
            {
                return RedirectToPage("/User/Profile");
            }
            SoftwareId = softwareId == default ? Softwares.FirstOrDefault().Id : softwareId;

            RolesModel = ApiExtension.GetAsync<IEnumerable<Model.Entity.Identity.Role>>(
                             GlobalParameter.ApiBaseAddress, "/api/Role/GetBySoftwareId",
                             HttpContext.Session.GetString("Token"),
                             new Dictionary<string, string>
                             {
                                 {"SoftwareId",SoftwareId.ToString()}
                             }).Result;
            return Page();
        }
    }
}