using MixMeal.Core.Models;
using MixMeal.Persistence.PostgreSQL;

namespace MixMeal.Modules.Recommendations.Abstractions
{
    public class DistanceRecommendationService : IRecommendationEngine
    {
        private readonly MixMealDbContext _dbContext;

        public DistanceRecommendationService(MixMealDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Menu> RecommendMenus(
            NutritionalValues expectedNutritionalValues, 
            IEnumerable<DishType> dishTypesToExclude)
            => _dbContext.Set<Menu>()
            .ToList()
            .Where(m => !HasDishesOfTypes(m, dishTypesToExclude))
            .OrderBy(m => m.Distance(expectedNutritionalValues))
            .Take(5);

        public IEnumerable<Dish> RecommendDishes(
            NutritionalValues expectedNutritionalValues, 
            DishType dishType)
            => _dbContext.Set<Dish>()
            .Where(d => d.DishType == dishType)
            .ToList()
            .OrderBy(m => m.Distance(expectedNutritionalValues))
            .Take(5);

        private bool HasDishesOfTypes(Menu menu, IEnumerable<DishType> dishesToCheck)
            => menu.Dishes.Select(d => d.DishType).Intersect(dishesToCheck).Any();
    }
}
