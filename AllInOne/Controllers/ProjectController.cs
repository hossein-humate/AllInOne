using System;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Model.Entity.AllInOne;
using Newtonsoft.Json;

namespace AllInOne.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : ApiBaseController
    {
        [HttpGet("GetAllAsync")]
        public IActionResult GetAllAsync()
        {
            var projects = UnitOfWork.Projects.Get();
            if (projects != null) return Ok(projects);

            return Ok();
        }

        [HttpPost("GetAsync")]
        public Project GetAsync(object id)
        {
            return UnitOfWork.Projects.GetById(Guid.Parse(id.ToString()));
        }

        [HttpPost("Insert")]
        public Project Insert(object obj)
        {
            try
            {
                var project = JsonConvert.DeserializeObject<Project>(obj.ToString());
                project.Id = Guid.NewGuid();
                UnitOfWork.Projects.Insert(project);
                UnitOfWork.Save();
                return project;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost("Update")]
        public Project Update(object obj)
        {
            try
            {
                var project = JsonConvert.DeserializeObject<Project>(obj.ToString());
                UnitOfWork.Projects.Update(project);
                UnitOfWork.Save();
                return project;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost("DeleteById")]
        public bool DeleteById(object id)
        {
            try
            {
                var result = UnitOfWork.Projects.DeleteById(Guid.Parse(id.ToString()));
                UnitOfWork.Save();
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}