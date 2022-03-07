using Evona.Task.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evona.Task.Persistence.Repositories
{
    public class GenericRepository<T, TSearch> : IGenericRepository<T, TSearch> where T : class where TSearch : class
    {
        private readonly EvonaTaskDbContext _dbContext;

        public GenericRepository(EvonaTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public virtual async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public virtual async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAll(TSearch search = null)
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
