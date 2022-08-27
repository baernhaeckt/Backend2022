using Microsoft.EntityFrameworkCore;
using MixMeal.Core.Models;

namespace MixMeal.Persistence.PostgreSQL;

public class UserRepository : PostgreSQLRepository<User>
{
    public UserRepository(MixMealDbContext dbContext) 
        : base(dbContext)
    {
    }
}
