using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class Visitor : Repository<Model.Entity.Identity.Visitor>, IVisitor
    {
        private readonly DatabaseContext _dbContext;
        public Visitor(DatabaseContext databaseContext)
            : base(databaseContext: databaseContext)
        {
            _dbContext = databaseContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
    public interface IVisitor : IRepository<Model.Entity.Identity.Visitor>
    {
        void Save();
    }
}
