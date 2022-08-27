using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using MixMeal.Core.Models;
using MixMeal.Modules.UserManagement.Abstraction;
using MixMeal.Modules.UserManagement.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace MixMeal.Persistence.PostgreSQL.IntegrationTests.UseCases;

[Collection("PostgreSQL")]
public class RegistrationUseCase
{
    private readonly PostgreSQLFixture _postgreSQLFixture;

    public RegistrationUseCase(PostgreSQLFixture postgreSQLFixture)
    {
        _postgreSQLFixture = postgreSQLFixture;
    }

    [Fact]
    public async Task UsersController_ShouldRegisterUser()
    {
        // Arrange
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(_postgreSQLFixture.OverwriteConnectionString);

        // Act
        var client = application.CreateClient();

        // Assert
        RegisterUserRequest request = new()
        {
            Email = "marc.sallin@outlook.com"
        };
        HttpResponseMessage response = await client.PostAsJsonAsync("api/users/register", request);
        response.EnsureSuccessStatusCode();

        UserLoginResponse result = await response.Content.ReadFromJsonAsync<UserLoginResponse>();
        result.Token.Should().NotBeNullOrWhiteSpace();
        _postgreSQLFixture.DbContext.Set<User>().FirstOrDefault(u => u.Email == request.Email).Should().NotBeNull();
    }

    [Fact]
    public async Task UsersController_ShouldLoginUser()
    {
        // Arrange
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(_postgreSQLFixture.OverwriteConnectionString);

        IPasswordStorage passwordStorage = application.Services.GetRequiredService<IPasswordStorage>();

        User user = new()
        {
            Id = Guid.NewGuid(),
            Firstname = "xsund",
            Lastname = "pfund",
            PasswordHash = passwordStorage.Create("1234"),
            Email = "xsund.pfund@test.ch"
        };
        _postgreSQLFixture.DbContext.Add(user);
        _postgreSQLFixture.DbContext.SaveChanges();

        var client = application.CreateClient();

        UserLoginRequest request = new()
        {
            Email = "xsund.pfund@test.ch",
            Password = "1234"
        };

        // Act
        HttpResponseMessage response = await client.PostAsJsonAsync("api/users/login", request);

        // Assert
        response.EnsureSuccessStatusCode();
        UserLoginResponse result = await response.Content.ReadFromJsonAsync<UserLoginResponse>();
        result.Token.Should().NotBeNullOrWhiteSpace();
        _postgreSQLFixture.DbContext.Set<User>().FirstOrDefault(u => u.Email == request.Email).Should().NotBeNull();
    }
}