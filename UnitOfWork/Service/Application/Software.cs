using System;
using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Application
{
    public class Software : Repository<Model.Entity.Application.Software>, ISoftware
    {
        public Software(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public bool IsValidApiKey(string apiKey, Guid softwareId)
        {
            var software=GetById(softwareId);
            if (software == null) return false;
            return software.ApiKey == apiKey;
        }
    }

    public interface ISoftware : IRepository<Model.Entity.Application.Software>
    {
        bool IsValidApiKey(string apiKey, Guid softwareId);
    }
}