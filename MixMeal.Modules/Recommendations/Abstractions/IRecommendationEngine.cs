using MixMeal.Core.Models;

namespace MixMeal.Modules.Recommendations.Abstractions;

public interface IRecommendationEngine
{
    public IEnumerable<Menu> RecommendMenus(
        NutritionalValues expectedNutritionalValues, 
        IEnumerable<DishType> dishTypesToExclude);

    public IEnumerable<Dish> RecommendDishes(
        NutritionalValues expectedNutritionalValues,
        DishType dishType);
}
