using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.BaseInfo
{
    public class MasterDetail : Repository<Model.Entity.BaseInfo.MasterDetail>, IMasterDetail
    {
        public MasterDetail(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IMasterDetail : IRepository<Model.Entity.BaseInfo.MasterDetail>
    {
    }
}