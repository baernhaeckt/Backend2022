using Microsoft.IdentityModel.Tokens;
using MixMeal.Modules.UserManagement.Abstraction;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MixMeal.Modules.UserManagement.Security;

public class JwtSecurityTokenFactory : ISecurityTokenFactory
{
    private const int TokenExpirationInMinutes = 60 * 24; // Set this to 15min after refresh is implemented.

    private readonly ISecurityKeyProvider _securityKeyProvider;

    public JwtSecurityTokenFactory(ISecurityKeyProvider securityKeyProvider) => _securityKeyProvider = securityKeyProvider;

    public string Create(Guid id, string subject, IEnumerable<string> roles)
    {
        var now = DateTime.Now;
        var claims = new List<Claim>
            {
                new Claim(Core.Extensions.ClaimTypes.UserId, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, subject),
                new Claim(JwtRegisteredClaimNames.Sub, subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.CurrentCulture), ClaimValueTypes.Integer64)
            };

        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        SymmetricSecurityKey signingKey = _securityKeyProvider.GetSecurityKey();
        var securityToken = new JwtSecurityToken(
            "MixMeal",
            "MixMeal",
            claims,
            now,
            now.AddMinutes(TokenExpirationInMinutes),
            new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
