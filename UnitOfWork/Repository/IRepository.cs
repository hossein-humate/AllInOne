using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UnitOfWork.Repository
{
    public interface IRepository<T> where T : Model.Entity.BaseEntity, IDisposable
    {
        T GetById(Guid id);

        T GetByIdAsNoTracking(Guid id);

        T GetAsNoTracking(Expression<Func<T, bool>> predicate);
        T Insert(T entity);

        void InsertRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeletePhysical(T entity);

        void DeleteRangePhysical(IEnumerable<T> entities);

        bool DeleteById(Guid id);

        bool DeleteByIdPhysically(Guid id);

        IQueryable<T> Get();

        IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetWithRawSql(string query, params object[] parameters);
        IQueryable<T> GetWithDeleted();
    }
}