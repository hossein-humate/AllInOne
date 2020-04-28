using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class Address : Repository<Model.Entity.Identity.Address>, IAddress
    {
        public Address(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IAddress : IRepository<Model.Entity.Identity.Address>
    {
    }
}