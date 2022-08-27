using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MixMeal.Core.Repositories;

namespace MixMeal.Persistence.PostgreSQL;

public class PostgreSQLRepository<TEntity> : IRepository<TEntity> where TEntity : class
{

    public PostgreSQLRepository(MixMealDbContext dbContext)
    {
        DbSet = dbContext.Set<TEntity>();
        DbContext = dbContext;
    }

    protected MixMealDbContext DbContext { get; }

    protected DbSet<TEntity> DbSet { get; }

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

    public IEnumerable<TEntity> GetAll() 
        => DbSet;
}
