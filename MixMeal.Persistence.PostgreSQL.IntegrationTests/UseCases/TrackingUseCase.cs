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

        var request1 = JsonSerializer.Deserialize<CallbackRequest>(TestData.GetForUser(user1.Id));
        var request2 = JsonSerializer.Deserialize<CallbackRequest>(TestData.GetForUser(user1.Id));
        var request3 = JsonSerializer.Deserialize<CallbackRequest>(TestData.GetForUser(user2.Id));

        // Act
        HttpResponseMessage response1 = await client.PostAsJsonAsync("api/tracking/callback", request1);
        HttpResponseMessage response2 = await client.PostAsJsonAsync("api/tracking/callback", request2);
        HttpResponseMessage response3 = await client.PostAsJsonAsync("api/tracking/callback", request3);

        // Assert
        response1.EnsureSuccessStatusCode();
        response2.EnsureSuccessStatusCode();
        response3.EnsureSuccessStatusCode();
        User? userFromDb = _postgreSQLFixture.DbContext.Set<User>()
            .Include(u => u.IntakeTrackingRecords)
            .FirstOrDefault(u => u.Id == user1.Id);

        userFromDb.Should().NotBeNull();
        userFromDb!.IntakeTrackingRecords.Count().Should().Be(2);
    }

    private static class TestData
    {
        public static string GetForUser(Guid userId) => @"{
    ""user_id"": ""oh"",
    ""token"": ""token"",
    ""estimations"": [
        {
            ""class_name"": ""vegetable"",
            ""estimated_calories"": 15.094855048323035,
            ""estimated_protein"": 15.094855048323035,
            ""estimated_fat"": 15.094855048323035,
            ""estimated_carbohydrates"": 15.094855048323035
        },
        {
            ""class_name"": ""fruit"",
            ""estimated_calories"": 4.450170344517813,
            ""estimated_protein"": 4.450170344517813,
            ""estimated_fat"": 4.450170344517813,
            ""estimated_carbohydrates"": 4.450170344517813
        },
        {
            ""class_name"": ""pasta"",
            ""estimated_calories"": 138.76781692406178,
            ""estimated_protein"": 21.161327638739067,
            ""estimated_fat"": 21.161327638739067,
            ""estimated_carbohydrates"": 295.57646930449204
        },
        {
            ""class_name"": ""fruit"",
            ""estimated_calories"": 4.815182642611842,
            ""estimated_protein"": 4.815182642611842,
            ""estimated_fat"": 4.815182642611842,
            ""estimated_carbohydrates"": 4.815182642611842
        },
        {
            ""class_name"": ""bread"",
            ""estimated_calories"": 63.626729164393105,
            ""estimated_protein"": 63.626729164393105,
            ""estimated_fat"": 39.93491758992442,
            ""estimated_carbohydrates"": 205.77759861120526
        },
        {
            ""class_name"": ""pork"",
            ""estimated_calories"": 166.77658631066376,
            ""estimated_protein"": 48.45965651929845,
            ""estimated_fat"": 255.51428365418772,
            ""estimated_carbohydrates"": 137.19735386282244
        }
    ]
}".Replace("oh", userId.ToString()).Replace("token", Guid.NewGuid().ToString());
    }
}