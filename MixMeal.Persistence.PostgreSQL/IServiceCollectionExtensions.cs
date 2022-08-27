using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MixMeal.Core.Repositories;

namespace MixMeal.Persistence.PostgreSQL;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddPostgreSQL(this IServiceCollection services, ConfigurationManager configuration)
        => services
        .AddDbContext<MixMealDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("MixMealDBContext")))
        .AddScoped(typeof(IRepository<>), typeof(PostgreSQLRepository<>));
}