using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MixMeal.Core.Models;
using MixMeal.Modules.UserManagement.Abstraction;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace MixMeal.Persistence.PostgreSQL.IntegrationTests.UseCases;

[Collection("PostgreSQL")]
public class UserProfileUseCase
{
    private readonly Guid _user1Id = Guid.Parse("af09657c-e006-4c4a-ab2f-e420a9c21df0");

    private readonly PostgreSQLFixture _postgreSQLFixture;

    public UserProfileUseCase(PostgreSQLFixture postgreSQLFixture)
    {
        _postgreSQLFixture = postgreSQLFixture;
    }

    [Fact]
    public async Task ProfileController_ShouldReturnUnauthorized_WhenNoJWT()
    {
        // Arrange
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(_postgreSQLFixture.OverwriteConnectionString);

        // Act
        var client = application.CreateClient();

        // Assert
        HttpResponseMessage response = await client.GetAsync("api/users/profile");
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task ProfileController_ShouldReturnUser()
    {
        // Arrage
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(_postgreSQLFixture.OverwriteConnectionString);

        User user = new()
        {
            Id = _user1Id,
            Firstname = "xsund",
            Lastname = "pfund",
            PasswordHash = "blah",
            Email = "xsund.pfund@test.ch"
        };
        _postgreSQLFixture.DbContext.Add(user);
        _postgreSQLFixture.DbContext.SaveChanges();

        ISecurityTokenFactory securityTokenFactory = application.Services.GetRequiredService<ISecurityTokenFactory>();
        string jwt = securityTokenFactory!.Create(user.Id, user.Email, Enumerable.Empty<string>());

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        // Act
        HttpResponseMessage response = await client.GetAsync("api/users/profile");

        // Assert
        response.EnsureSuccessStatusCode();
        string result = await response.Content.ReadAsStringAsync();
        result.Should().Be("{\"id\":\"af09657c-e006-4c4a-ab2f-e420a9c21df0\",\"displayName\":\"xsund pfund\",\"email\":\"xsund.pfund@test.ch\",\"sex\":\"Female\",\"age\":0,\"height\":0,\"activityFactor\":\"LittleOrNo\",\"dailyDemand\":{\"calories\":-161,\"proteins\":-8.05,\"carbohydrates\":-10.867500000000001,\"fat\":-4.830000000000001},\"intakeTrackingRecords\":[]}");
    }
}