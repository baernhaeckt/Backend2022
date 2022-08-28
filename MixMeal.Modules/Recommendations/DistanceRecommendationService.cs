using Microsoft.EntityFrameworkCore;
using MixMeal.Core.Models;
using MixMeal.Modules.Recommendations.Abstractions;
using MixMeal.Persistence.PostgreSQL;

namespace MixMeal.Modules.Recommendations;

public class DistanceRecommendationEngine : IRecommendationEngine
{
    private readonly MixMealDbContext _dbContext;

    public DistanceRecommendationEngine(MixMealDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Menu> RecommendMenus(
        NutritionalValues expectedNutritionalValues,
        IEnumerable<DishType> dishTypesToExclude)
        => _dbContext.Set<Menu>()
        .Include(m => m.Dishes)
        .ThenInclude(d => d.Ingredients)
        .ToList()
        .Where(m => !HasDishesOfTypes(m, dishTypesToExclude))
        .OrderBy(m => m.Distance(expectedNutritionalValues))
        .Take(5);

    public IEnumerable<Dish> RecommendDishes(
        NutritionalValues expectedNutritionalValues,
        DishType dishType)
        => _dbContext.Set<Dish>()
        .Include(d => d.Ingredients)
        .Where(d => d.DishType == dishType)
        .ToList()
        .OrderBy(m => m.Distance(expectedNutritionalValues))
        .Take(5);

    private bool HasDishesOfTypes(Menu menu, IEnumerable<DishType> dishesToCheck)
        => menu.Dishes.Select(d => d.DishType).Intersect(dishesToCheck).Any();
}
