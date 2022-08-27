using Microsoft.Extensions.DependencyInjection;
namespace MixMeal.Modules.Menus;

public static class Registrar
{
    public static IServiceCollection AddMenu(this IServiceCollection services)
        => services.AddScoped<MenuRepository>();
}
