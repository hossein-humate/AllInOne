using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class RolePermission : Repository<Model.Entity.Identity.RolePermission>, IRolePermission
    {
        public RolePermission(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IRolePermission : IRepository<Model.Entity.Identity.RolePermission>
    {
    }
}