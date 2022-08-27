using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MixMeal.Core.Repositories;

namespace MixMeal.Persistence.PostgreSQL;

public class PostgreSQLRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbSet<TEntity> DbSet;

    protected readonly MixMealDbContext DbContext;

    public PostgreSQLRepository(MixMealDbContext dbContext)
    {
        DbSet = dbContext.Set<TEntity>();
        DbContext = dbContext;
    }

    public IQueryable<TEntity> Queryable => DbSet.AsQueryable();

    public async Task<TEntity> Create(TEntity entity)
    {
        EntityEntry<TEntity> result = DbSet.Add(entity);
        await DbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task Delete(TEntity entity)
    {
        DbSet.Remove(entity);
        await DbContext.SaveChangesAsync();
    }

    public IAsyncEnumerable<TEntity> GetAll()
            => DbSet.AsAsyncEnumerable();
}
