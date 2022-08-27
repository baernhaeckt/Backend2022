﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Extensions;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;
using MixMeal.Modules.Recommendations.Abstractions;
using MixMeal.Modules.Recommendations.Models;

namespace MixMeal.Modules.Recommendations.Controllers;

[ApiController]
[Route("api/recommend/menu")]
public class MenuRecommendationController : ControllerBase
{
    private readonly IRecommendationEngine _recommendationEngine;

    private readonly IUserRepository _userRepository;

    private readonly IMenueNutritionalValuesCalculator _nutritionalValuesCalculator;

    public MenuRecommendationController(IUserRepository userRepository, IMenueNutritionalValuesCalculator nutritionalValuesCalculator, IRecommendationEngine recommendationEngine)
    {
        _recommendationEngine = recommendationEngine;
        _userRepository = userRepository;
        _nutritionalValuesCalculator = nutritionalValuesCalculator;
    }

    [HttpPost]
    public async Task<RecommendMenuResponse> Recommend([FromBody] RecommendMenuRequest request)
    {
        User user = await _userRepository.GetByIdOrThrowAsync(HttpContext.User.Id());
        NutritionalValues nutritionalValues = _nutritionalValuesCalculator.Calculate(user.GetDailyDemand(), user.GetDailyIntake());
        IEnumerable<Menu> menus = _recommendationEngine.RecommendMenus(nutritionalValues, request.Except);
        return new RecommendMenuResponse(menus);
    }
}
