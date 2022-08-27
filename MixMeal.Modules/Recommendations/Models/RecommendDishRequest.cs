using MixMeal.Core.Models;

namespace MixMeal.Modules.Recommendations.Models;

public record RecommendDishRequest(Menu Menu, DishType DishType);