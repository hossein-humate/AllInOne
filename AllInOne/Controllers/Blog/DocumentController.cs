using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.DTO.PageModel;
using Model.Entity.Blog;
using Newtonsoft.Json;
using Utility;
using Utility.Helpers;
using static System.String;

namespace AllInOne.Controllers.Blog
{
    [Route("api/[controller]")]
    public class DocumentController : ApiBaseController
    {
        [HttpGet("GetAll")]
        public IEnumerable<Document> GetAll()
        {
            var documents = UnitOfWork.Documents.Get().ToList();
            return documents;
        }

        [HttpGet("GetAllDocumentListForTreeView")]
        public IEnumerable<JsTree> GetAllPermissionListForTreeViewBySoftwareId()
        {
            var jsTreeItems = UnitOfWork.Documents.Get().Select(p => new JsTree()
            {
                id = p.Id.ToString(),
                parent = p.ParentId == Guid.Empty ? "#" : p.ParentId.ToString(),
                text = p.Name,
                state = new JsTreeState
                {
                    opened = p.ParentId == Guid.Empty || p.Childrens.Any(),
                    selected = p.ParentId == Guid.Empty
                }
            }).ToList();
            return jsTreeItems;
        }

        [HttpGet("GetByIdWithImageChildrens")]
        public Document GetByIdWithImageChildrens()
        {
            var document = UnitOfWork.Documents.Get(d=>
                    d.Id==Request.Headers["Id"].ToGuid())
                .Include(d => d.DocumentImages)
                .Include(ag => ag.Childrens)
                .FirstOrDefault();
            if (document == null) return null;
            document.VisitNumber++;
            UnitOfWork.Documents.Update(document);
            UnitOfWork.Save();
            return document;
        }

        [HttpGet("GetForSelectList")]
        public IEnumerable<SelectListItem> GetForSelectList()
        {
            var documents = UnitOfWork.Documents.Get().Select(p => new SelectListItem
                {
                    Text = $"نام مستند: {(IsNullOrWhiteSpace(p.Name) ? "نا مشخص" : p.Name)}",
                    Value = p.Id.ToString()
                }).ToList();
            return documents;
        }

        [HttpPost("GetById")]
        public Document GetById(object id)
        {
            var document = UnitOfWork.Documents.GetById(id.ToGuid());
            return document;
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var document = JsonConvert.DeserializeObject<Document>(obj.ToString());
                UnitOfWork.Documents.Insert(document);
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
                var document = JsonConvert.DeserializeObject<Document>(obj.ToString());
                var tempDocument = UnitOfWork.Documents.GetById(document.Id);
                tempDocument.Name = document.Name;
                tempDocument.Title = document.Title;
                tempDocument.Summary = document.Summary;
                tempDocument.Author = document.Author;
                tempDocument.SortOrder = document.SortOrder;
                tempDocument.ParentId = document.ParentId;
                tempDocument.MetaDescription = document.MetaDescription;
                tempDocument.MetaRobots = document.MetaRobots;
                tempDocument.MetaKeywords = document.MetaKeywords;
                tempDocument.IsActive = document.IsActive;
                tempDocument.Description = document.Description;
                UnitOfWork.Documents.Update(tempDocument);
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
                UnitOfWork.Documents.DeleteById(id.ToGuid());
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام حذف اطلاعات خطایی رخ داد!";
            }
        }
    }
}