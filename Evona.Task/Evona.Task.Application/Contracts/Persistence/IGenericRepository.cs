using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evona.Task.Application.Contracts.Persistence
{
    public interface IGenericRepository<T, TSearch> where T : class where TSearch : class
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll(TSearch search = null);
        Task<bool> Exists(int id);
        Task<T> Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
