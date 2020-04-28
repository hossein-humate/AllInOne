using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Blog
{
    public class DocumentImage : Repository<Model.Entity.Blog.DocumentImage>, IDocumentImage
    {
        public DocumentImage(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IDocumentImage : IRepository<Model.Entity.Blog.DocumentImage>
    {
    }
}
