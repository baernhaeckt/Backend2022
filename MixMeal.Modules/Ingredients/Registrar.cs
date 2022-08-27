using Microsoft.Extensions.DependencyInjection;

namespace MixMeal.Modules.Ingredients;

public static class Registrar
{
    public static IServiceCollection AddIngredients(this IServiceCollection services)
        => services.AddScoped<IngredientsRepository>();
}
