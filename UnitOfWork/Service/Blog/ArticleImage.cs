using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Blog
{
    public class ArticleImage : Repository<Model.Entity.Blog.ArticleImage>, IArticleImage
    {
        public ArticleImage(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IArticleImage : IRepository<Model.Entity.Blog.ArticleImage>
    {
    }
}