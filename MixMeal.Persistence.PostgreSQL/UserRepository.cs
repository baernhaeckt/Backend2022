using Microsoft.EntityFrameworkCore;
using MixMeal.Core;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;

namespace MixMeal.Persistence.PostgreSQL;

public class UserRepository : PostgreSQLRepository<User>, IUserRepository
{
    public UserRepository(MixMealDbContext dbContext) 
        : base(dbContext)
    {
    }

    public async Task<User> GetByEmailOrThrowAsync(string email)
    {
        User? user = await DbSet.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            throw new EntityNotFoundException<User>(email);
        }

        return user;
    }

    public async Task<User> GetByIdOrThrowAsync(Guid id, bool includeIntakeRecords = false)
    {
        User? user = includeIntakeRecords
            ? await DbSet.Include(u => u.IntakeTrackingRecords).FirstOrDefaultAsync(u => u.Id == id)
            : await DbSet.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new EntityNotFoundException<User>(id);
        }

        return user;
    }
}
