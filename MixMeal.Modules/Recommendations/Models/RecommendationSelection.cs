using MixMeal.Core.Models;

namespace MixMeal.Modules.Recommendations.Models;

public record RecommendationSelection(IReadOnlyCollection<DishType> DishTypes);