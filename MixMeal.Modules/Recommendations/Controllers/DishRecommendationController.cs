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
        NutritionalValues baseNutritionalValues = _nutritionalValuesCalculator.Calculate(user.DailyDemand, user.DailyIntake);
        NutritionalValues alreadySelectedValues = FromDishes(request.Menu.Dishes);

        IEnumerable<Dish> dishes = _recommendationEngine.RecommendDishes(
            baseNutritionalValues.Diff(alreadySelectedValues), 
            request.DishType);

        return new RecommendDishResponse(dishes);
    }

    private NutritionalValues FromDishes(IEnumerable<Dish> dishes)
    {
        return new NutritionalValues()
        {
            Calories = dishes.Sum(d => d.Calories),
            Proteins = dishes.Sum(d => d.Proteins),
            Carbohydrates = dishes.Sum(d => d.Carbohydrates),
            Fat = dishes.Sum(d => d.Fat),
        };
    }
}