using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class Phone : Repository<Model.Entity.Identity.Phone>, IPhone
    {
        public Phone(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IPhone : IRepository<Model.Entity.Identity.Phone>
    {
    }
}