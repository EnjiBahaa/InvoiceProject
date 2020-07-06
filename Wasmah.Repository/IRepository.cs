using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Wasmah.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> CreateOnDbAsync(TEntity entity);
        Task CreateRangeAsync(params TEntity[] entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(object id);
        Task<int> SaveChangesAsync();
    }
}
