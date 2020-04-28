using DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace UnitOfWork.Repository
{
    public class Repository<T> : object, IRepository<T> where T : BaseEntity
    {
        public Repository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            DbSet = DatabaseContext.Set<T>();
        }
        private DbSet<T> DbSet { get; set; }
        private DatabaseContext DatabaseContext { get; set; }
        public T GetById(Guid id)
        {
            T obj = DbSet.Find(id);
            return (obj);
        }

        public T GetByIdAsNoTracking(Guid id)
        {
            T obj = DbSet.AsNoTracking().ToList().Find(x => x.Id == id);
            return (obj);
        }

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.IsDeleted = false;
            entity.IsActive = true;
            entity.CreationDate = DateTime.Now;
            entity.LastModifiedDate = DateTime.Now;
            return DbSet.Add(entity: entity).Entity;
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            DbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.IsDeleted = false;
            entity.LastModifiedDate = DateTime.Now;
            EntityState oEntityState = DatabaseContext.Entry(entity: entity).State;
            if (oEntityState == EntityState.Detached)
            {
                DbSet.Attach(entity: entity);
            }
            DatabaseContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            DbSet.UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.IsActive = false;
            entity.IsDeleted = true;
            entity.LastModifiedDate = DateTime.Now;
            entity.DeletionDate = DateTime.Now;
            EntityState oEntityState = DatabaseContext.Entry(entity: entity).State;
            if (oEntityState == EntityState.Detached)
            {
                DbSet.Attach(entity: entity);
            }
            DatabaseContext.Entry(entity).State = EntityState.Modified;
        }

        public void DeletePhysical(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            EntityState oEntityState =
                DatabaseContext.Entry(entity: entity).State;
            if (oEntityState == EntityState.Detached)
            {
                DbSet.Attach(entity: entity);
            }
            DbSet.Remove(entity: entity);
        }

        public void DeleteRangePhysical(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            DbSet.RemoveRange(entities);
        }

        public bool DeleteById(Guid id)
        {
            T entity = GetById(id: id);
            if (entity == null)
            {
                return (false);
            }
            entity.IsDeleted = true;
            entity.LastModifiedDate = DateTime.Now;
            entity.DeletionDate = DateTime.Now;
            entity.IsActive = false;
            EntityState oEntityState =
                DatabaseContext.Entry(entity: entity).State;

            if (oEntityState == EntityState.Detached)
            {
                DbSet.Attach(entity: entity);
            }
            DatabaseContext.Entry(entity).State = EntityState.Modified;
            return (true);
        }

        public bool DeleteByIdPhysically(Guid id)
        {
            T oEntity = GetById(id: id);
            if (oEntity == null)
            {
                return (false);
            }
            Delete(entity: oEntity);
            return (true);
        }

        public IQueryable<T> Get()
        {
            return (DbSet.Where(current => current.IsDeleted == false));
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return (DbSet.Where(predicate: predicate).Where(current => current.IsDeleted == false));
        }

        public T GetAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate: predicate).FirstOrDefault(current => current.IsDeleted == false);
        }

        public IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
        {
            return DbSet.FromSqlRaw(sql: query, parameters: parameters).ToList();
        }

        public IQueryable<T> GetWithDeleted()
        {
            return (DbSet);
        }

        #region IDisposable Support
        ~Repository() { Dispose(true); }

        private bool _disposed;
        private readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _handle.Dispose();
            }
            _disposed = true;
        }
        #endregion
    }
}