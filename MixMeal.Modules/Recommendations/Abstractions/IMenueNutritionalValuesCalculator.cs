using MixMeal.Core.Models;

namespace MixMeal.Modules.Recommendations.Abstractions;

/// <summary>
/// Calculates the nutritional values a menu should have.
/// </summary>
public interface IMenueNutritionalValuesCalculator
{
    public NutritionalValues Calculate(NutritionalValues dailyDemand, NutritionalValues dailyIntake);
}
