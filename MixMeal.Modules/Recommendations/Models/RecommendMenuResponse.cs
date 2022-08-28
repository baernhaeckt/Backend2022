using MixMeal.Core.Models;

namespace MixMeal.Modules.Recommendations.Models;

public record RecommendMenuResponse(IEnumerable<Menu> Menus, NutritionalValues DailyDemand, NutritionalValues DailyInTake, NutritionalValues Recommendation);
