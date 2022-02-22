using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Shared.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Add(List<TEntity> entity);

        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        void UpdateItem(string id);
        Task<TEntity> GetByIdAsync(int id);
        TEntity GetByStingId(string id);
        TEntity GetById(int id);
        Task<List<TEntity>> GetByName(string id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> filter2 = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAll(Func<TEntity, bool> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params object[] includes);
    }
}
