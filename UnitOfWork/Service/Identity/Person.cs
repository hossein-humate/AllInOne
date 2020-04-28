using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class Person : Repository<Model.Entity.Identity.Person>, IPerson
    {
        public Person(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IPerson : IRepository<Model.Entity.Identity.Person>
    {
    }
}