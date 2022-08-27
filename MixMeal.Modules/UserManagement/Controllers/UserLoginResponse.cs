namespace MixMeal.Modules.UserManagement.Controllers;

public class UserLoginResponse
{
    public UserLoginResponse(string token) => Token = token;

    public string Token { get; set; }
}