using MixMeal.Core.Models;

namespace MixMeal.Modules.Recommendations.Models;

public record RecommendDishResponse(IEnumerable<Dish> Dishes);
