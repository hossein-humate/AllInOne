using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Entity.Identity;
using Newtonsoft.Json;
using Utility;
using Utility.Helpers;
using static System.String;

namespace AllInOne.Controllers.Identity
{
    [Route("api/[controller]")]
    public class PersonController : ApiBaseController
    {
        private readonly IImageWriter _imageWriter;
        public PersonController(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Person> GetAll()
        {
            var persons = UnitOfWork.Persons.Get().ToList();
            return persons;
        }

        [HttpGet("GetForSelectList")]
        public IEnumerable<SelectListItem> GetForSelectList()
        {
            var persons = UnitOfWork.Persons.Get().Select(p => new SelectListItem
            {
                Text = p.Firstname + " " + p.Lastname,
                Value = p.Id.ToString()
            }).ToList();
            return persons;
        }

        [HttpPost("GetById")]
        public Person GetById(object id)
        {
            var person = UnitOfWork.Persons.GetById(id.ToGuid());
            return person;
        }

        [HttpPost("Create")]
        public string Create(object obj)
        {
            try
            {
                var person = JsonConvert.DeserializeObject<Person>(obj.ToString());
                UnitOfWork.Persons.Insert(person);
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
                var person = JsonConvert.DeserializeObject<Person>(obj.ToString());
                var tempPerson = UnitOfWork.Persons.GetById(person.Id);
                tempPerson.LastModifiedDate = DateTime.Now;
                tempPerson.Lastname = person.Lastname;
                tempPerson.Firstname = person.Firstname;
                tempPerson.Middlename = person.Middlename;
                tempPerson.Gender = person.Gender;
                tempPerson.Description = person.Description;
                tempPerson.NationalId = person.NationalId;
                tempPerson.PicturePath = person.PicturePath;
                UnitOfWork.Persons.Update(tempPerson);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
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
                    GlobalParameter.CdnLocalPath + GlobalParameter.PersonImagePath).Result;
            }
            catch (Exception)
            {
                return Empty;
            }
        }

        [HttpPost("DeleteById")]
        public string DeleteById(object id)
        {
            try
            {
                UnitOfWork.Persons.DeleteById(id.ToGuid());
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