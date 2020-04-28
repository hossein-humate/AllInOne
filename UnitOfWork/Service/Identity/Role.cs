using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class Role : Repository<Model.Entity.Identity.Role>, IRole
    {
        public Role(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IRole : IRepository<Model.Entity.Identity.Role>
    {
    }
}