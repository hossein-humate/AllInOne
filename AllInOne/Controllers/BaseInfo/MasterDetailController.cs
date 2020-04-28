using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;
using static System.String;

namespace AllInOne.Controllers.BaseInfo
{
    [Route("api/[controller]")]
    public class MasterDetailController : ApiBaseController
    {
        [HttpGet("GetAllMaster")]
        public IEnumerable<Model.Entity.BaseInfo.MasterDetail> GetAllMaster()
        {
            var masterDetails = UnitOfWork.MasterDetails.Get(m => m.MasterId == Guid.Empty).ToList();
            return masterDetails;
        }

        [HttpPost("GetAllDetail")]
        public IEnumerable<Model.Entity.BaseInfo.MasterDetail> GetAllDetail(object id)
        {
            var masterDetails = UnitOfWork.MasterDetails.Get(m => m.MasterId == id.ToGuid())
                .OrderBy(m => m.Order).ToList();
            return masterDetails;
        }

        [HttpPost("GetById")]
        public Model.Entity.BaseInfo.MasterDetail GetById(object id)
        {
            var masterDetail = UnitOfWork.MasterDetails.GetById(id.ToGuid());
            return masterDetail;
        }

        [HttpPost("CreateMaster")]
        public string CreateMaster(object obj)
        {
            try
            {
                var masterDetail = JsonConvert
                    .DeserializeObject<Model.Entity.BaseInfo.MasterDetail>(obj.ToString());
                string validateResult = ValidateInputs(masterDetail);
                if (!IsNullOrWhiteSpace(validateResult))
                {
                    return validateResult;
                }
                masterDetail.MasterId = Guid.Empty;
                UnitOfWork.MasterDetails.Insert(masterDetail);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }


        [HttpPost("UpdateMaster")]
        public string UpdateMaster(object obj)
        {
            try
            {
                var masterDetail = JsonConvert
                    .DeserializeObject<Model.Entity.BaseInfo.MasterDetail>(obj.ToString());
                string validateResult = ValidateInputs(masterDetail, true);
                if (!IsNullOrWhiteSpace(validateResult))
                {
                    return validateResult;
                }
                masterDetail.MasterId = Guid.Empty;
                masterDetail.IsActive = true;
                UnitOfWork.MasterDetails.Update(masterDetail);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }

        [HttpPost("CreateDetail")]
        public string CreateDetail(object obj)
        {
            try
            {
                var masterDetail = JsonConvert
                    .DeserializeObject<Model.Entity.BaseInfo.MasterDetail>(obj.ToString());
                UnitOfWork.MasterDetails.Insert(masterDetail);
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام ذخیره اطلاعات خطایی رخ داد!";
            }
        }


        [HttpPost("UpdateDetail")]
        public string UpdateDetail(object obj)
        {
            try
            {
                var masterDetail = JsonConvert
                    .DeserializeObject<Model.Entity.BaseInfo.MasterDetail>(obj.ToString());
                masterDetail.IsActive = true;
                UnitOfWork.MasterDetails.Update(masterDetail);
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
                UnitOfWork.MasterDetails.DeleteById(id.ToGuid());
                UnitOfWork.Save();
                return Empty;
            }
            catch (Exception)
            {
                return "در هنگام حذف اطلاعات خطایی رخ داد!";
            }
        }

        public string ValidateInputs(Model.Entity.BaseInfo.MasterDetail model, bool updateMode = false)
        {
            IQueryable<Model.Entity.BaseInfo.MasterDetail> masterDetails = UnitOfWork.MasterDetails.Get();
            if (updateMode)
            {
                if (masterDetails.Any(u => u.Title == model.Title && u.Id != model.Id))
                {
                    return "عنوان پارامتر وارد شده قبل ذخبره شده است.";
                }
                return Empty;
            }

            if (masterDetails.Any(u => u.Title == model.Title))
            {
                return "عنوان پارامتر وارد شده قبل ذخبره شده است.";
            }
            return Empty;
        }
    }
}