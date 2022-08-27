using MixMeal.Core.Models;
using MixMeal.Modules.Recommendations.Abstractions;

namespace MixMeal.Modules.Recommendations;

internal class MenueNutritionalValuesCalculator : IMenueNutritionalValuesCalculator
{
    public NutritionalValues Calculate(NutritionalValues dailyDemand, NutritionalValues dailyIntake)
    {
        return new NutritionalValues()
        {
            Calories = dailyDemand.Calories - dailyIntake.Calories,
            Proteins = dailyDemand.Proteins - dailyIntake.Proteins,
            Carbohydrates = dailyDemand.Carbohydrates - dailyIntake.Carbohydrates,
            Fat = dailyDemand.Fat - dailyIntake.Fat
        };
    }
}