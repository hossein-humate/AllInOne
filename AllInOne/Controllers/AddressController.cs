using System;
using System.Collections.Generic;
using AllInOne.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Model.Entity.Identity;
using Newtonsoft.Json;

namespace AllInOne.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : ApiBaseController
    {
        [HttpGet("GetAllAsync")]
        public IActionResult GetAllAsync()
        {
            var addresses = UnitOfWork.Address.Get(s => s.IsDeleted == false);
            if (addresses != null) return Ok(addresses);

            return Ok();
        }

        [HttpPost("GetAsync")]
        public Address GetAsync(object id)
        {
            var address = UnitOfWork.Address.GetById(Guid.Parse(id.ToString()));
            return address;
        }

        [HttpPost("GetByUserIdAsync")]
        public IEnumerable<Address> GetByUserIdAsync(object id)
        {
            var addresses = UnitOfWork.Address.Get(a => a.UserId == Guid.Parse(id.ToString()));
            return addresses;
        }

        [HttpPost("Insert")]
        public Address Insert(object obj)
        {
            try
            {
                var address = JsonConvert.DeserializeObject<Address>(obj.ToString());
                address.Id = Guid.NewGuid();
                //address.UserId = LoginResponse.UserId;
                UnitOfWork.Address.Insert(address);
                UnitOfWork.Save();
                return address;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost("Update")]
        public Address Update(object obj)
        {
            try
            {
                var address = JsonConvert.DeserializeObject<Address>(obj.ToString());
                UnitOfWork.Address.Update(address);
                UnitOfWork.Save();
                return address;
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
                var result = UnitOfWork.Address.DeleteById(Guid.Parse(id.ToString()));
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