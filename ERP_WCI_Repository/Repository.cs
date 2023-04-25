using ERP_WCI_Context;
using ERP_WCI_Model;
using ERP_WCI_Model.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERP_WCI_Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected Context _db;

        protected Context context;

        public Repository(Context db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<ICollection<TEntity>> GetListAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetListAllIncludeAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include = null)
        {
            return await _db.Set<TEntity>().Where(predicate).Include(include).ToListAsync();
        }

        public async Task<int> GetListAllCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).CountAsync();
        }

        public async Task<ICollection<TEntity>> GetListPaginationOrderByAsync(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (where != null)
                query = query.Where(where).OrderBy(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            else
                return await query.ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetListPaginationOrderByInclueAsync(Expression<Func<TEntity, object>> orderpagination, BasePagination pagination, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (where != null)
            {
                if (include != null)
                {
                    if (include.Body is NewExpression)
                    {
                        (include.Body as NewExpression).Arguments.ToList().ForEach(x =>
                        {
                            var inc = x as MemberExpression;
                            string s = inc.ToString();
                            s = s[(s.IndexOf('.') + 1)..];
                            query = query.Include(s);
                        });

                        query = query.Where(where).OrderBy(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);
                    }
                    else
                    {
                        query = query.Where(where).Include(include).OrderBy(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);
                    }
                }
                else
                {
                    query = query.Where(where).Include(include).OrderBy(orderpagination).Skip(pagination.PageSkip).Take(pagination.PageTake);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<dynamic> AddAsync(TEntity entity)
        {
            entity = BeforAdd(entity);
            using var tc = _db.Database.BeginTransaction();
            try
            {
                _db.Entry(entity).State = EntityState.Added;
                var id = await _db.SaveChangesAsync();
                tc.Commit();
                ClearEntityCache();
                return id;
            }
            catch (Exception ex)
            {
                tc.Rollback();
                throw new Exception(ex.InnerException.InnerException.Message.ToString());
            }
        }

        public async Task DeleteAsync(Func<TEntity, bool> predicate)
        {
            using var tc = _db.Database.BeginTransaction();
            try
            {
                _db.Set<TEntity>().Where(predicate).ToList().ForEach(del => _db.Set<TEntity>().Remove(del));
                await _db.SaveChangesAsync();
                tc.Commit();
            }
            catch (Exception ex)
            {
                tc.Rollback();
                throw new Exception(ex.InnerException.InnerException.Message.ToString());
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity = BeforUpdate(entity);
            using var tc = _db.Database.BeginTransaction();
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                var update = await _db.SaveChangesAsync();
                tc.Commit();
                ClearEntityCache();
                return entity;
            }
            catch (Exception ex)
            {
                tc.Rollback();
                throw new Exception(ex.InnerException.InnerException.Message.ToString());
            }
        }

        protected virtual TEntity BeforAdd(TEntity entity)
        {
            entity.UserID = entity.UserID;
            entity.UserIDLastUpdate = entity.UserIDLastUpdate;
            entity.Active = true;
         
            entity.CreateDate = DateTime.Now;
            entity.ModifieldDate = DateTime.Now;
            return entity;
        }

        protected virtual TEntity BeforUpdate(TEntity entity)
        {
            entity.UserIDLastUpdate = entity.UserIDLastUpdate;
            entity.ModifieldDate = DateTime.Now;
            return entity;
        }

        private void ClearEntityCache()
        {
            try
            {
                foreach (EntityEntry dbEntityEntry in _db.ChangeTracker.Entries())
                    if (dbEntityEntry.Entity != null)
                        dbEntityEntry.State = EntityState.Detached;
            }
            catch
            {
            }
        }
    }
}
