using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Blog
{
    public class ArticleGroup : Repository<Model.Entity.Blog.ArticleGroup>, IArticleGroup
    {
        public ArticleGroup(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IArticleGroup : IRepository<Model.Entity.Blog.ArticleGroup>
    {
    }
}