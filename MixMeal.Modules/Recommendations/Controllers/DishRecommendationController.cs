using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Extensions;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;
using MixMeal.Modules.Recommendations.Abstractions;
using MixMeal.Modules.Recommendations.Models;

namespace MixMeal.Modules.Recommendations.Controllers;

[ApiController]
[Route("api/recommend/dish")]
public class DishRecommendationController : ControllerBase
{
    private readonly IRecommendationEngine _recommendationEngine;

    private readonly IUserRepository _userRepository;

    private readonly IMenueNutritionalValuesCalculator _nutritionalValuesCalculator;

    public DishRecommendationController(
        IUserRepository userRepository,
        IMenueNutritionalValuesCalculator nutritionalValuesCalculator,
        IRecommendationEngine recommendationEngine)
    {
        _recommendationEngine = recommendationEngine;
        _userRepository = userRepository;
        _nutritionalValuesCalculator = nutritionalValuesCalculator;
    }

    /// <summary>
    ///     Requests a new recommendation for the <see cref="Dish"/> of <see cref="DishType"/> based
    ///     on personal information and the currently selected <see cref="Menu"/>.
    /// </summary>
    [HttpPost]
    public async Task<RecommendDishResponse> GetRecommendations([FromBody] RecommendDishRequest request)
    {
        User user = await _userRepository.GetByIdOrThrowAsync(HttpContext.User.Id());
        NutritionalValues nutritionalValues = _nutritionalValuesCalculator.Calculate(user.DailyDemand, user.DailyIntake);
        IEnumerable<Dish> dishes = _recommendationEngine.RecommendDishes(nutritionalValues, request.DishType);
        return new RecommendDishResponse(dishes);
    }
}