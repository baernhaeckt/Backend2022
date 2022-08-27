using FluentAssertions;
using Microsoft.Extensions.Configuration;
using MixMeal.Modules.UserManagement.Security;
using System.Collections.Generic;
using Xunit;

namespace MixMeal.Web.UnitTests.Modules.UserManagement.Security;

public class StaticPasswordGeneratorFixture
{
    [Fact]
    public void Generate_CreatesRandomPassword()
    {
        // Arrange
        var inMemorySettings = new Dictionary<string, string>
        {
            {"DefaultPassword", "static"}
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var randomPasswordGenerator = new StaticPasswordGenerator(configuration);

        // Act
        string password = randomPasswordGenerator.Generate();

        // Assert
        password.Should().Be("static");
    }
}
