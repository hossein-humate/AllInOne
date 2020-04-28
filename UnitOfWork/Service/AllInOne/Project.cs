using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.AllInOne
{
    public class Project : Repository<Model.Entity.AllInOne.Project>, IProject
    {
        public Project(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IProject : IRepository<Model.Entity.AllInOne.Project>
    {
    }
}