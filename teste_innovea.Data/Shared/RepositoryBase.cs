using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace teste_innovea.Data.Shared
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : EntityBase
    {
        protected readonly teste_innoveaDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(teste_innoveaDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region Metodos sincronos
        public void Add(TEntity obj)
        {
            _dbSet.Add(obj).State = EntityState.Added;
            SaveChanges();
        }

        public TEntity Get(int Id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == Id);
        }

        public IEnumerable<TEntity> List()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Update(TEntity obj)
        {
            _dbSet.Update(obj).State = EntityState.Modified;
            SaveChanges();
        }

        public void Remove(int Id)
        {
            TEntity entity = Get(Id);
            Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Attach(entity).State = EntityState.Deleted;
                _dbSet.Remove(entity);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        #endregion

        #region Metodos assincronos
        public virtual async Task<TEntity> GetAsync(int Id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(t => t.Id == Id);
        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        #endregion
    }
}
