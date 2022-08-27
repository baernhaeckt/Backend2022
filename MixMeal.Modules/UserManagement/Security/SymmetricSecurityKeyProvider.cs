using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MixMeal.Modules.UserManagement.Abstraction;
using System.Text;

namespace MixMeal.Modules.UserManagement.Security;

public class SymmetricSecurityKeyProvider : ISecurityKeyProvider
{

    private readonly Func<string> _JwtSecurityKeyFetcher;

    public SymmetricSecurityKeyProvider(IConfiguration configuration) => _JwtSecurityKeyFetcher = () => configuration["JwtSecurityKey"];

    public SymmetricSecurityKeyProvider(string key) => _JwtSecurityKeyFetcher = () => key;
    public SymmetricSecurityKey GetSecurityKey() => new(Encoding.UTF8.GetBytes(_JwtSecurityKeyFetcher()));
}
