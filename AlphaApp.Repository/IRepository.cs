using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaApp.DataRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IList<TEntity>> GetAllAsync();
        Task<int> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
