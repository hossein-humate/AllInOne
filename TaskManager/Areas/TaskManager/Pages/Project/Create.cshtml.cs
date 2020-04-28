using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.DTO.General;
using Model.Entity.Identity;
using Utility;

namespace TaskManager.Areas.TaskManager.Pages.Project
{
    public class CreateModel : PageModel
    {
        public MessageAlert MessageAlert;

        public CreateModel()
        {
            MessageAlert = new MessageAlert();
        }

        public SelectList Persons { get; set; }

        [BindProperty(SupportsGet = true)] public Model.Entity.AllInOne.Project ProjectModel { get; set; }

        public IActionResult OnGet()
        {
            Persons = null;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            ProjectModel.TeamLeaderId = Request.Form["drpTeamLeader"].ToGuid();
            if (!ValidateInputs()) return OnGet();

            try
            {
                var result = await ApiExtension.PostAsync<Model.Entity.AllInOne.Project,
                    Model.Entity.AllInOne.Project>(GlobalParameter.ApiBaseAddress,
                    "/api/Project/Insert", ProjectModel);
                if (result == null)
                {
                    MessageAlert.Message = "درج پروژه جدید با مشکل مواجه شد.";
                    MessageAlert.CssClass = "bg-danger";
                    return Page();
                }

                MessageAlert.Message = "درج پروژه جدید با موفقیت انجام شد.";
                MessageAlert.CssClass = "bg-success";
                return RedirectToPage("Edit", new {id = result.Id, message = MessageAlert.Message});
            }
            catch (Exception)
            {
                return BadRequest("خطا در هنگام ذخیره اطلاعات");
            }
        }

        public bool ValidateInputs()
        {
            try
            {
                //    var role = await ApiExtension.GetAsync<IEnumerable<Model.Identity.Role>>(GlobalParameters.ApiBaseAddress,
                //        "/api/Role/GetAllAsync");
                //    if (ProjectModel.SoftwareId == null || ProjectModel.SoftwareId == Guid.Empty)
                //    {
                //        MessageAlert.Message = "نرم افزار مورد نظر را انتخاب نمایید.";
                //        MessageAlert.CssClass = "bg-warning";
                //        return false;
                //    }
                //    if (role.Any(u => u.SoftwareId == ProjectModel.SoftwareId && u.Name == ProjectModel.Name))
                //    {
                //        MessageAlert.Message = "نام گروه وارد شده قبلا برای این نرم افزار ذخبره شده است.";
                //        MessageAlert.CssClass = "bg-warning";
                //        return false;
                //    }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}