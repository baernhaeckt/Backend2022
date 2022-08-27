using Microsoft.IdentityModel.Tokens;

namespace MixMeal.Modules.UserManagement.Abstraction;

public interface ISecurityKeyProvider
{
    SymmetricSecurityKey GetSecurityKey();
}