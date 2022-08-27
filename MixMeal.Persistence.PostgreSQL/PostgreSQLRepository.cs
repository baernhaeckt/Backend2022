using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MixMeal.Core.Repositories;

namespace MixMeal.Persistence.PostgreSQL
{
    public class PostgreSQLRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly MixMealDbContext _dbContext;

        public PostgreSQLRepository(MixMealDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Queryable => _dbSet.AsQueryable();

        public async Task<TEntity> Create(TEntity entity)
        {
            EntityEntry<TEntity> result = _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IAsyncEnumerable<TEntity> GetAll()
            => _dbSet.AsAsyncEnumerable();
    }
}