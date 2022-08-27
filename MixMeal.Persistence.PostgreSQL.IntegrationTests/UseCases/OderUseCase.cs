using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Options;
using MixMeal.Core.Models;
using MixMeal.Modules.UserManagement.Abstraction;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace MixMeal.Persistence.PostgreSQL.IntegrationTests.UseCases;

[Collection("PostgreSQL")]
public class OrderUseCase
{
    private readonly PostgreSQLFixture _postgreSQLFixture;

    public OrderUseCase(PostgreSQLFixture postgreSQLFixture)
    {
        _postgreSQLFixture = postgreSQLFixture;
    }

    [Fact]
    public async Task OrderUseCase_ShouldReturnMenus()
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

        // Act
        HttpResponseMessage response = await client.PostAsync("api/orders", new StringContent(TestData.GetMenu(), Encoding.UTF8, "application/json"));

        // Assert
        response.EnsureSuccessStatusCode();
    }

    private static class TestData
    {
        public static string GetMenu() => @"{ 
    ""dishes"": [{ 
            ""name"": ""SuperBowl"", 
            ""dishType"": ""Bowl"", 
            ""dishSize"": ""Small"", 
            ""ingredients"": [{ 
                    ""name"": ""Rüebli"", 
                    ""icon"": ""🥕"", 
                    ""allergies"": [], 
                    ""tags"": [], 
                    ""premium"": false, 
                    ""validDishTypes"": [""Bowl"", ""Ice""], 
                    ""calories"": 17, 
                    ""proteins"": 0, 
                    ""carbohydrates"": 7, 
                    ""fat"": 0 
                }, { 
                    ""name"": ""Rüebli"", 
                    ""icon"": ""🥕"", 
                    ""allergies"": [], 
                    ""tags"": [], 
                    ""premium"": false, 
                    ""validDishTypes"": [""Bowl"", ""Ice""], 
                    ""calories"": 17, 
                    ""proteins"": 0, 
                    ""carbohydrates"": 7, 
                    ""fat"": 0 
                }, { 
                    ""name"": ""Avocado"", 
                    ""icon"": ""🥑"", 
                    ""allergies"": [], 
                    ""tags"": [], 
                    ""premium"": false, 
                    ""validDishTypes"": [""Bowl"", ""Ice""], 
                    ""calories"": 17, 
                    ""proteins"": 0, 
                    ""carbohydrates"": 7, 
                    ""fat"": 120 
                }, { 
                    ""name"": ""Pilzli"", 
                    ""icon"": ""🍄"", 
                    ""allergies"": [], 
                    ""tags"": [], 
                    ""premium"": false, 
                    ""validDishTypes"": [""Bowl"", ""Ice""], 
                    ""calories"": 30, 
                    ""proteins"": 0, 
                    ""carbohydrates"": 10, 
                    ""fat"": 10 
                } 
            ], 
            ""id"": 571746079, 
            ""calories"": 0, 
            ""proteins"": 0, 
            ""carbohydrates"": 0, 
            ""fat"": 0 
        }, { 
            ""name"": ""PowerCube"", 
            ""dishType"": ""PotatoCubes"", 
            ""dishSize"": ""Small"", 
            ""ingredients"": [{ 
                    ""name"": ""Potato"", 
                    ""icon"": ""🥔"", 
                    ""allergies"": [], 
                    ""tags"": [], 
                    ""premium"": false, 
                    ""validDishTypes"": [""PotatoCubes""], 
                    ""calories"": 23, 
                    ""proteins"": 0, 
                    ""carbohydrates"": 3, 
                    ""fat"": 1 
                } 
            ], 
            ""id"": 552841342, 
            ""calories"": 0, 
            ""proteins"": 0, 
            ""carbohydrates"": 0, 
            ""fat"": 0 
        }, { 
            ""name"": ""Dr Sünder"", 
            ""dishType"": ""Ice"", 
            ""dishSize"": ""Small"", 
            ""ingredients"": [{ 
                    ""name"": ""Vanille"", 
                    ""icon"": ""🍨"", 
                    ""allergies"": [], 
                    ""tags"": [], 
                    ""premium"": false, 
                    ""validDishTypes"": [""Ice""], 
                    ""calories"": 70, 
                    ""proteins"": 0, 
                    ""carbohydrates"": 3, 
                    ""fat"": 10 
                } 
            ], 
            ""id"": 663237020, 
            ""calories"": 0, 
            ""proteins"": 0, 
            ""carbohydrates"": 0, 
            ""fat"": 0 
        } 
    ], 
    ""name"": ""Your Favorite"", 
    ""id"": 715133690, 
    ""calories"": 0, 
    ""proteins"": 0, 
    ""carbohydrates"": 0, 
    ""fat"": 0, 
    ""payment"": ""postfinance-alternate2"" 
}";
    }
}