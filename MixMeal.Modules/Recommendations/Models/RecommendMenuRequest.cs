using MixMeal.Core.Models;

namespace MixMeal.Modules.Recommendations.Models;

public record RecommendMenuRequest(IEnumerable<DishType> Except);
