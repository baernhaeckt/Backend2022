using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using MixMeal.Core.Models;
using MixMeal.Modules.UserManagement.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using MixMeal.Modules.Recommendations.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MixMeal.Persistence.PostgreSQL.IntegrationTests.UseCases;

[Collection("PostgreSQL")]
public class TrackingUseCase
{
    private readonly PostgreSQLFixture _postgreSQLFixture;

    public TrackingUseCase(PostgreSQLFixture postgreSQLFixture)
    {
        _postgreSQLFixture = postgreSQLFixture;
    }

    [Fact]
    public async Task RecommendationUseCase_ShouldReturnMenus()
    {
        // Arrage
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(_postgreSQLFixture.OverwriteConnectionString);

        JsonSerializerOptions jsonSerializerOptions = application.Services.GetRequiredService<IOptions<JsonOptions>>().Value.JsonSerializerOptions;

        User user1 = new()
        {
            Id = Guid.NewGuid(),
            Firstname = "xsund",
            Lastname = "pfund",
            PasswordHash = "blah",
            Email = "xsund.pfund@test.ch"
        };

        User user2 = new()
        {
            Id = Guid.NewGuid(),
            Firstname = "xsund2",
            Lastname = "pfund2",
            PasswordHash = "blah",
            Email = "xsund.pfund1@test.ch"
        };

        _postgreSQLFixture.DbContext.Add(user1);
        _postgreSQLFixture.DbContext.Add(user2);
        _postgreSQLFixture.DbContext.SaveChanges();
        _postgreSQLFixture.DbContext.ChangeTracker.Clear();

        ISecurityTokenFactory securityTokenFactory = application.Services.GetRequiredService<ISecurityTokenFactory>();
        string jwt = securityTokenFactory!.Create(user1.Id, user1.Email, Enumerable.Empty<string>());

        var client = application.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        
        CallbackRequest request1 = new()
        {
            Calories = 240,
            Fat = 12,
            Carbohydrates = 11,
            Proteins = 12,
            Token = Guid.NewGuid(),
            UserId = user1.Id
        };

        CallbackRequest request2 = new()
        {
            Calories = 145,
            Fat = 8,
            Carbohydrates = 1,
            Proteins = 12,
            Token = Guid.NewGuid(),
            UserId = user1.Id
        };
        
        CallbackRequest request3 = new()
        {
            Calories = 240,
            Fat = 12,
            Carbohydrates = 11,
            Proteins = 12,
            Token = Guid.NewGuid(),
            UserId = user2.Id // For another user
        };

        // Act
        HttpResponseMessage response1 = await client.PostAsJsonAsync("api/tracking/callback", request1);
        HttpResponseMessage response2 = await client.PostAsJsonAsync("api/tracking/callback", request2);
        HttpResponseMessage response3 = await client.PostAsJsonAsync("api/tracking/callback", request3);

        // Assert
        response1.EnsureSuccessStatusCode();
        response2.EnsureSuccessStatusCode();
        response3.EnsureSuccessStatusCode();
        User userFromDb = _postgreSQLFixture.DbContext.Set<User>()
            .Include(u => u.IntakeTrackingRecords)
            .FirstOrDefault(u => u.Id == user1.Id);

        userFromDb.Should().NotBeNull();
        userFromDb.IntakeTrackingRecords.Count().Should().Be(2);
    }
}