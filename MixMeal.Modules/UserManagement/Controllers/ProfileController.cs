using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Extensions;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;

namespace MixMeal.Modules.UserManagement.Controllers;

[Route("api/users/profile")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public ProfileController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<UserProfileResponse> Get()
    {
        User user = await _userRepository.GetByIdOrThrowAsync(HttpContext.User.Id());
        UserProfileResponse result = new(
            user.Id,
            user.DisplayName,
            user.Email,
            user.Sex,
            user.Age,
            user.Height,
            user.ActivityFactor,
            user.DailyDemand,
            user.IntakeTrackingRecords
            );
        return result;
    }
}
