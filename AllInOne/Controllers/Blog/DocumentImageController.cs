using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entity.Blog;
using Newtonsoft.Json;
using Utility;
using Utility.Helpers;
using static System.String;

namespace AllInOne.Controllers.Blog
{
    [Route("api/[controller]")]
    public class DocumentImageController : ApiBaseController
    {
        private readonly IImageWriter _imageWriter;
        public DocumentImageController(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        [HttpGet("GetAll")]
        public IEnumerable<DocumentImage> GetAll()
        {
            var docImages = UnitOfWork.DocumentImages.Get().ToList();
            return docImages;
        }

        [HttpGet("GetByDocumentId")]
        public IEnumerable<DocumentImage> GetByDocumentId()
        {
            var docImages = UnitOfWork.DocumentImages.Get(ai =>
            ai.DocumentId == Request.Headers["DocumentId"].ToGuid())
               .Include(ai => ai.Document).ToList();
            return docImages;
        }

        [HttpPost("GetById")]
        public DocumentImage GetById(object id)
        {
            var docImages = UnitOfWork.DocumentImages.GetById(id.ToGuid());
            return docImages;
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
                    GlobalParameter.CdnLocalPath + GlobalParameter.DocumentImagePath).Result;
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
                var docImages = JsonConvert.DeserializeObject<DocumentImage>(obj.ToString());
                UnitOfWork.DocumentImages.Insert(docImages);
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
                var docImages = JsonConvert.DeserializeObject<DocumentImage>(obj.ToString());
                var tempaDocImage = UnitOfWork.DocumentImages.GetById(docImages.Id);
                tempaDocImage.Name = docImages.Name;
                tempaDocImage.Alt = docImages.Alt;
                tempaDocImage.Caption = docImages.Caption;
                tempaDocImage.Width = docImages.Width;
                tempaDocImage.Height = docImages.Height;
                tempaDocImage.DocumentId = docImages.DocumentId;
                tempaDocImage.IsActive = docImages.IsActive;
                tempaDocImage.Description = docImages.Description;
                UnitOfWork.DocumentImages.Update(tempaDocImage);
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
                UnitOfWork.DocumentImages.DeleteById(id.ToGuid());
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