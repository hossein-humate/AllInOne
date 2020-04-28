using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Finance
{
    public class Transaction : Repository<Model.Entity.Finance.Transaction>, ITransaction
    {
        public Transaction(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface ITransaction : IRepository<Model.Entity.Finance.Transaction>
    {
    }
}
