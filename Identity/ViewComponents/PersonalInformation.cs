using Microsoft.AspNetCore.Mvc;
using Model.Entity.Identity;
using System;
using Utility;

namespace Identity.ViewComponents
{
    [ViewComponent(Name = "PersonalInformation")]
    public class PersonalInformation : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            try
            {
                var user = HttpContext.Session.Get<User>("CurrentUser");
                return View("/Areas/Identity/Pages/Components/_PersonalInformation.cshtml", user);
            }
            catch (Exception)
            {
                return View("/Areas/Identity/Pages/Components/_PersonalInformation.cshtml", new User());
            }
        }
    }
}
