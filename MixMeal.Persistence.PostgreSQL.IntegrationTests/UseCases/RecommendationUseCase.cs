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
using MixMeal.Modules.Recommendations.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

namespace MixMeal.Persistence.PostgreSQL.IntegrationTests.UseCases;

[Collection("PostgreSQL")]
public class RecommendationUseCase
{
    private readonly PostgreSQLFixture _postgreSQLFixture;

    public RecommendationUseCase(PostgreSQLFixture postgreSQLFixture)
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

        User user = new()
        {
            Id = Guid.NewGuid(),
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
        RecommendMenuRequest request = new(Enumerable.Empty<DishType>());

        // Act
        HttpResponseMessage response = await client.PostAsJsonAsync("api/recommend/menu", request);

        // Assert
        response.EnsureSuccessStatusCode();
        RecommendMenuResponse result = await response.Content.ReadFromJsonAsync<RecommendMenuResponse>(jsonSerializerOptions);
        result.Menus.Should().HaveCountGreaterThan(0);
    }
}