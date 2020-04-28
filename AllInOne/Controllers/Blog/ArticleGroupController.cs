using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entity.Blog;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utility;
using Utility.Helpers;
using static System.String;

namespace AllInOne.Controllers.Blog
{
    [Route("api/[controller]")]
    public class ArticleGroupController : ApiBaseController
    {
        private readonly IImageWriter _imageWriter;
        public ArticleGroupController(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        [HttpGet("GetAll")]
        public IEnumerable<ArticleGroup> GetAll()
        {
            var articleGroups = UnitOfWork.ArticleGroups.Get().ToList();
            return articleGroups;
        }

        [HttpGet("GetAllWithArticleAndChilds")]
        public IEnumerable<ArticleGroup> GetAllWithArticleAndChilds()
        {
            var articleGroups = UnitOfWork.ArticleGroups.Get()
                .Include(ag=>ag.Childrens)
                .Include(ag=>ag.Articles).ToList();
            return articleGroups;
        }

        [HttpGet("GetForSelectList")]
        public IEnumerable<SelectListItem> GetForSelectList()
        {
            var articleGroups = UnitOfWork.ArticleGroups.Get(r =>
                r.Id != Request.Headers["ArticleGroupId"].ToGuid()).Select(p => new SelectListItem
                {
                    Text = $"نام گروه مقاله: {(IsNullOrWhiteSpace(p.Name) ? "نا مشخص" : p.Name)}",
                    Value = p.Id.ToString()
                }).ToList();
            return articleGroups;
        }

        [HttpPost("GetById")]
        public ArticleGroup GetById(object id)
        {
            var articleGroup = UnitOfWork.ArticleGroups.GetById(id.ToGuid());
            return articleGroup;
        }

        [HttpPost("SaveImageFile")]
        public string SaveImageFile([FromForm]IFormFile file)
        {
            try
            {
                var validateResult = ValidateInputs(file);
                if (!IsNullOrWhiteSpace(validateResult))
                {
                    return validateResult;
                }
                return _imageWriter.UploadImage(file,
                    GlobalParameter.CdnLocalPath + GlobalParameter.ArticleImagePath).Result;
            }
            catch (Exception)
            {
                return Empty;
            }
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var articleGroup = JsonConvert.DeserializeObject<ArticleGroup>(obj.ToString());
                UnitOfWork.ArticleGroups.Insert(articleGroup);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }

        [HttpPost("Update")]
        public string Update(object obj)
        {
            try
            {
                var articleGroup = JsonConvert.DeserializeObject<ArticleGroup>(obj.ToString());
                var temparticleGroup = UnitOfWork.ArticleGroups.GetById(articleGroup.Id);
                temparticleGroup.Name = articleGroup.Name;
                temparticleGroup.Title = articleGroup.Title;
                temparticleGroup.ParentId = articleGroup.ParentId;
                temparticleGroup.Image = articleGroup.Image;
                temparticleGroup.MetaDescription = articleGroup.MetaDescription;
                temparticleGroup.MetaRobots = articleGroup.MetaRobots;
                temparticleGroup.MetaKeywords = articleGroup.MetaKeywords;
                temparticleGroup.IsActive = articleGroup.IsActive;
                temparticleGroup.Description = articleGroup.Description;
                UnitOfWork.ArticleGroups.Update(temparticleGroup);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }

        [HttpPost("DeleteById")]
        public string DeleteById(object id)
        {
            try
            {
                UnitOfWork.ArticleGroups.DeleteById(id.ToGuid());
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام حذف اطلاعات خطایی رخ داد!";
            }
        }

        public string ValidateInputs(IFormFile model, bool updateMode = false)
        {
            using (var memoryStream = new MemoryStream())
            {
                model.CopyTo(memoryStream);
                if (memoryStream.Length > 2097152)
                {
                    return "حجم تصویر بیشتر از 2 مگابایت نباید باشد.";
                }
            }
            return Empty;
        }
    }
}