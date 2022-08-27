using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Extensions;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;

namespace MixMeal.Modules.UserManagement.Controllers;

[Route("api/profile")]
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
        UserProfileResponse result = new(user.DisplayName, user.Email);
        return result;
    }
}
