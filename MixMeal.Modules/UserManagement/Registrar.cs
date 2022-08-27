using Microsoft.Extensions.DependencyInjection;
using MixMeal.Modules.UserManagement.Abstraction;
using MixMeal.Modules.UserManagement.Controllers;

namespace MixMeal.Modules.UserManagement;

public static class Registrar
{
    public static IServiceCollection AddUserManagement(this IServiceCollection services)
    {
        // Security Utilities
        services.AddSingleton<ISecurityTokenFactory, FakeSecurityTokenFactory>();
        services.AddSingleton<IPasswordStorage, FakePasswordStorage>();

        return services;
    }
}
