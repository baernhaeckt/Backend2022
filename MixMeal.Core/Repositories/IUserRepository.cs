using MixMeal.Core.Models;

namespace MixMeal.Core.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByIdOrThrowAsync(Guid id, bool includeIntakeRecords = false);

    Task<User> GetByEmailOrThrowAsync(string email);
}