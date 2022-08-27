using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MixMeal.Modules.UserManagement.Abstraction;
using System.Text;

namespace MixMeal.Modules.UserManagement.Security;

public class SymmetricSecurityKeyProvider : ISecurityKeyProvider
{
    private readonly IConfiguration _configuration;

    public SymmetricSecurityKeyProvider(IConfiguration configuration) => _configuration = configuration;

    public SymmetricSecurityKey GetSecurityKey() => new(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
}
