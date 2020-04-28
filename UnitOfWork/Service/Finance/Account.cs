using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Finance
{
    public class Account : Repository<Model.Entity.Finance.Account>, IAccount
    {
        public Account(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IAccount : IRepository<Model.Entity.Finance.Account>
    {
    }
}
