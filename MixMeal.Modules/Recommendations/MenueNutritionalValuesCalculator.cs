using MixMeal.Core.Models;
using MixMeal.Modules.Recommendations.Abstractions;

namespace MixMeal.Modules.Recommendations;

internal class MenueNutritionalValuesCalculator : IMenueNutritionalValuesCalculator
{
    public NutritionalValues Calculate(NutritionalValues dailyDemand, NutritionalValues dailyIntake)
    {
        return dailyDemand;
    }
}