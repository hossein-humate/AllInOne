using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Application
{
    public class Database : Repository<Model.Entity.Application.Database>, IDatabase
    {
        public Database(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IDatabase : IRepository<Model.Entity.Application.Database>
    {
    }
}