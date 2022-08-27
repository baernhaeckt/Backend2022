using Microsoft.Extensions.DependencyInjection;
using MixMeal.Modules.UserManagement.Abstraction;
using MixMeal.Modules.UserManagement.Security;

namespace MixMeal.Modules.UserManagement;

public static class Registrar
{
    public static IServiceCollection AddUserManagement(this IServiceCollection services)
    {
        // Security Utilities
        services.AddSingleton<ISecurityTokenFactory, JwtSecurityTokenFactory>();
        services.AddSingleton<IPasswordStorage, HmacSha512PasswordStorage>();
        services.AddSingleton<IPasswordGenerator, StaticPasswordGenerator>();
        services.AddSingleton<ISecurityKeyProvider, SymmetricSecurityKeyProvider>();

        return services;
    }
}
