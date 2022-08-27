using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;
using MixMeal.Modules.UserManagement.Abstraction;

namespace MixMeal.Modules.UserManagement.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ISecurityTokenFactory _securityTokenFactory;

    private readonly IPasswordStorage _passwordStorage;

    private readonly IPasswordGenerator _passwordGenerator;

    private readonly IUserRepository _userRepository;

    public UsersController(ISecurityTokenFactory securityTokenFactory, IPasswordStorage passwordStorage, IPasswordGenerator passwordGenerator, IUserRepository userRepository)
    {
        _securityTokenFactory = securityTokenFactory;
        _passwordStorage = passwordStorage;
        _passwordGenerator = passwordGenerator;
        _userRepository = userRepository;
    }

    [HttpPost(nameof(Login))]
    [AllowAnonymous]
    public async Task<ActionResult<UserLoginResponse>> Login([FromBody] UserLoginRequest request)
    {
        var user = await _userRepository.GetByEmailOrThrowAsync(request.Email.ToLowerInvariant());
        if (user == null || !_passwordStorage.Match(request.Password, user.PasswordHash))
        {
            return Unauthorized();
        }

        var response = new UserLoginResponse(_securityTokenFactory.Create(user.Id, user.Email, Enumerable.Empty<string>()));
        Response.Headers.Add("Authorization", $"Bearer {response.Token}");
        return new ActionResult<UserLoginResponse>(response);
    }

    [HttpPost(nameof(Register))]
    [AllowAnonymous]
    public async Task<ActionResult<UserLoginResponse>> Register([FromBody] RegisterUserRequest request)
    {
        string password = _passwordGenerator.Generate();
        var user = new User { Email = request.Email, PasswordHash = _passwordStorage.Create(password) };
        await _userRepository.Create(user);

        var response = new UserLoginResponse(_securityTokenFactory.Create(user.Id, user.Email, Enumerable.Empty<string>()));
        Response.Headers.Add("Authorization", $"Bearer {response.Token}");
        return new ActionResult<UserLoginResponse>(response);
    }
}
