using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.ClientApi
{
    public class Request : Repository<Model.Entity.ClientApi.Request>, IRequest
    {
        private readonly DatabaseContext _dbContext;
        public Request(DatabaseContext databaseContext)
            : base(databaseContext)
        {
            _dbContext = databaseContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }

    public interface IRequest : IRepository<Model.Entity.ClientApi.Request>
    {
        void Save();
    }
}
