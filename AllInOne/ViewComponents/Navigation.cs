using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entity.Identity;
using System;
using System.Collections.Generic;
using Model.DTO.PageModel;
using Utility;

namespace AllInOne.ViewComponents
{
    [ViewComponent(Name = "Navigation")]
    public class Navigation : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            try
            {
                var currentUser = HttpContext.Session.Get<User>("CurrentUser");
                var userPermissions = ApiExtension.PostAsync<IEnumerable<Permission>, RequestParameters>(
                    GlobalParameter.ApiBaseAddress,
                    "/api/User/GetUserAllPermissions",new RequestParameters
                    {
                        Param1 = currentUser.Id,
                        Param2 = currentUser.SoftwareId,
                    },
                    HttpContext.Session.GetString("Token")).Result;
                return View("/Pages/Shared/Panel/_Navigation.cshtml", userPermissions);
            }
            catch (Exception)
            {
                return View("/Pages/Shared/Panel/_Navigation.cshtml", new List<Permission>());
            }
        }
    }
}
