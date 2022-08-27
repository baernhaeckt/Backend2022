using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Models;
using MixMeal.Modules.Recommendations.Models;

namespace MixMeal.Modules.Recommendations.Controllers;

[ApiController]
[Route("api/recommend/dish")]
public class DishRecommendationController
{
    /// <summary>
    ///     Requests a new recommendation for the <see cref="Dish"/> of <see cref="DishType"/> based
    ///     on personal information and the currently selected <see cref="Menu"/>.
    /// </summary>
    [HttpPost]
    public IAsyncEnumerable<DishRecommendation> GetRecommendations([FromBody] RecommendDishRequest request)
    {
        return null;
    }
}