using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace teste_innovea.Data.Shared
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> List();
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(int Id);
        void Remove(TEntity entity);
        #region Metotos Assincronos
        Task<TEntity> GetAsync(int Id);
        Task<IEnumerable<TEntity>> ListAsync();
        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}