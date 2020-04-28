using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class Email : Repository<Model.Entity.Identity.Email>, IEmail
    {
        public Email(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IEmail : IRepository<Model.Entity.Identity.Email>
    {
    }
}