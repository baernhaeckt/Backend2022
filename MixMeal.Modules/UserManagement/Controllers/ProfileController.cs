using Microsoft.AspNetCore.Mvc;

namespace MixMeal.Modules.UserManagement.Controllers;

[Route("api/profile")]
[ApiController]
public class ProfileController : ControllerBase
{
    [HttpGet]
    public Task<UserProfileResponse> Get()
    {
        UserProfileResponse result = new("Marc", "marc.sallin@outlook.com");
        return Task.FromResult(result);
    }
}
