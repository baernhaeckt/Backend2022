using Microsoft.EntityFrameworkCore;
using MixMeal.Core.Repositories;

namespace MixMeal.Persistence.PostgreSQL;

public class PostgreSQLRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> dbSet;

    public PostgreSQLRepository(DbSet<TEntity> dbSet)
    {
        this.dbSet = dbSet;
    }

    public Task<TEntity> Create(TEntity entity)
        => Task.FromResult(dbSet.Add(entity).Entity);

    public Task Delete(TEntity entity)
        => Task.Run(() => dbSet.Remove(entity));

    public IAsyncEnumerable<TEntity> GetAll()
        => dbSet.AsAsyncEnumerable();
}