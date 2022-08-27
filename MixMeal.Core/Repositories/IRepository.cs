namespace MixMeal.Core.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> Create(TEntity entity);

    Task Delete(TEntity entity);

    IAsyncEnumerable<TEntity> GetAll();
}