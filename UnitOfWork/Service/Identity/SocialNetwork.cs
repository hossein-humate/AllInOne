using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Identity
{
    public class SocialNetwork : Repository<Model.Entity.Identity.SocialNetwork>, ISocialNetwork
    {
        public SocialNetwork(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface ISocialNetwork : IRepository<Model.Entity.Identity.SocialNetwork>
    {
    }
}