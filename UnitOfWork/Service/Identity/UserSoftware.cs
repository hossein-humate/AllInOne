using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class UserSoftware : Repository<Model.Entity.Identity.UserSoftware>, IUserSoftware
    {
        public UserSoftware(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IUserSoftware : IRepository<Model.Entity.Identity.UserSoftware>
    {
    }
}
