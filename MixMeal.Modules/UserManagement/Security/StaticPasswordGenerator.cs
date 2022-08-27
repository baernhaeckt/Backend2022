using Microsoft.Extensions.Configuration;
using MixMeal.Modules.UserManagement.Abstraction;

namespace MixMeal.Modules.UserManagement.Security;

public class StaticPasswordGenerator : IPasswordGenerator
{
    private readonly IConfiguration _configuration;

    public StaticPasswordGenerator(IConfiguration configuration) => _configuration = configuration;

    public string Generate() => _configuration["DefaultPassword"];
}