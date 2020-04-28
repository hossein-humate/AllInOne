using DataAccess.DbContext;
using UnitOfWork.Repository;

namespace UnitOfWork.Service.Blog
{
    public class Article : Repository<Model.Entity.Blog.Article>, IArticle
    {
        public Article(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }

    public interface IArticle : IRepository<Model.Entity.Blog.Article>
    {
    }
}
