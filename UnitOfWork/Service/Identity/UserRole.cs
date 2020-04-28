using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class UserRole : Repository<Model.Entity.Identity.UserRole>, IUserRole
    {
        public UserRole(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IUserRole : IRepository<Model.Entity.Identity.UserRole>
    {
    }
}