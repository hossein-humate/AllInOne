using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class Permission : Repository<Model.Entity.Identity.Permission>, IPermission
    {
        public Permission(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IPermission : IRepository<Model.Entity.Identity.Permission>
    {
    }
}