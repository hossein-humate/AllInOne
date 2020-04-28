using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Blog
{
    public class Document : Repository<Model.Entity.Blog.Document>, IDocument
    {
        public Document(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IDocument : IRepository<Model.Entity.Blog.Document>
    {
    }
}
