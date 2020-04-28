using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ArticleController : ApiBaseController
    {
        private readonly IImageWriter _imageWriter;
        public ArticleController(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Article> GetAll()
        {
            var articles = UnitOfWork.Articles.Get().ToList();
            return articles;
        }

        [HttpGet("GetAllWithGroupAndImage")]
        public IEnumerable<Article> GetAllWithGroupAndImage()
        {
            var articles = UnitOfWork.Articles.Get(a =>
            a.ArticleGroupId == Request.Headers["ArticleGroupId"].ToGuid())
                .Include(a => a.ArticleGroup)
                .Include(a => a.ArticleImages).ToList();
            return articles;
        }

        [HttpGet("GetWithGroupAndImage")]
        public Article GetWithGroupAndImage()
        {
            var article = UnitOfWork.Articles.Get(a =>
                    a.Id == Request.Headers["Id"].ToGuid())
                .Include(a => a.ArticleGroup)
                .Include(a => a.ArticleImages).FirstOrDefault();
            if (article == null) return null;
            article.VisitNumber++;
            UnitOfWork.Articles.Update(article);
            UnitOfWork.Save();
            return article;
        }

        [HttpPost("GetById")]
        public Article GetById(object id)
        {
            var article = UnitOfWork.Articles.GetById(id.ToGuid());
            return article;
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
                var article = JsonConvert.DeserializeObject<Article>(obj.ToString());
                UnitOfWork.Articles.Insert(article);
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
                var article = JsonConvert.DeserializeObject<Article>(obj.ToString());
                var temparticle = UnitOfWork.Articles.GetById(article.Id);
                temparticle.Name = article.Name;
                temparticle.Title = article.Title;
                temparticle.Image = article.Image;
                temparticle.Summary = article.Summary;
                temparticle.ArticleGroupId = article.ArticleGroupId;
                temparticle.Author = article.Author;
                temparticle.MetaDescription = article.MetaDescription;
                temparticle.MetaRobots = article.MetaRobots;
                temparticle.MetaKeywords = article.MetaKeywords;
                temparticle.IsActive = article.IsActive;
                temparticle.Description = article.Description;
                UnitOfWork.Articles.Update(temparticle);
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
                UnitOfWork.Articles.DeleteById(id.ToGuid());
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