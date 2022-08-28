using Microsoft.Extensions.DependencyInjection;
using MixMeal.Modules.Recommendations.Abstractions;

namespace MixMeal.Modules.Recommendations;

public static class Registrar
{
    public static IServiceCollection AddRecommendation(this IServiceCollection services)
        => services
        .AddScoped<IRecommendationEngine, DistanceRecommendationEngine>()
        .AddSingleton<IMenueNutritionalValuesCalculator, MenueNutritionalValuesCalculator>();
}
