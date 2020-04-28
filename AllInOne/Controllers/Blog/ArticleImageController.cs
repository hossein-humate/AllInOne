using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entity.Blog;
using Utility.Helpers;
using static System.String;
using Utility;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;

namespace AllInOne.Controllers.Blog
{
    [Route("api/[controller]")]
    public class ArticleImageController : ApiBaseController
    {
        private readonly IImageWriter _imageWriter;
        public ArticleImageController(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        [HttpGet("GetAll")]
        public IEnumerable<ArticleImage> GetAll()
        {
            var articleImages = UnitOfWork.ArticleImages.Get().ToList();
            return articleImages;
        }

        [HttpGet("GetByArticleId")]
        public IEnumerable<ArticleImage> GetByArticleId()
        {
            var articleImages = UnitOfWork.ArticleImages.Get(ai =>
            ai.ArticleId == Request.Headers["ArticleId"].ToGuid())
               .Include(ai => ai.Article).ToList();
            return articleImages;
        }

        [HttpPost("GetById")]
        public ArticleImage GetById(object id)
        {
            var articleImage = UnitOfWork.ArticleImages.GetById(id.ToGuid());
            return articleImage;
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
                var articleImage = JsonConvert.DeserializeObject<ArticleImage>(obj.ToString());
                UnitOfWork.ArticleImages.Insert(articleImage);
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
                var articleImage = JsonConvert.DeserializeObject<ArticleImage>(obj.ToString());
                var temparticleImage = UnitOfWork.ArticleImages.GetById(articleImage.Id);
                temparticleImage.Name = articleImage.Name;
                temparticleImage.Alt = articleImage.Alt;
                temparticleImage.Caption = articleImage.Caption;
                temparticleImage.Width = articleImage.Width;
                temparticleImage.Height = articleImage.Height;
                temparticleImage.ArticleId = articleImage.ArticleId;
                temparticleImage.IsActive = articleImage.IsActive;
                temparticleImage.Description = articleImage.Description;
                UnitOfWork.ArticleImages.Update(temparticleImage);
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
                UnitOfWork.ArticleImages.DeleteById(id.ToGuid());
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