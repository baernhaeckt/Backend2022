
using MixMeal.Core.Models;

namespace MixMeal.Modules.Recommendations.Models;

public record DishRecommendation(Dish Dish, RecommendationType RecommendationType);