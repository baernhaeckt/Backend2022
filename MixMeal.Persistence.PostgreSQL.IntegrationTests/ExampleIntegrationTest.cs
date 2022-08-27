using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace MixMeal.Persistence.PostgreSQL.IntegrationTests;

[Collection("PostgreSQL")]
public class ExampleIntegrationTest
{
    [Fact]
    public Task HelloWorldTest()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // ... Configure test services
            });

        var client = application.CreateClient();
        //...

        return Task.CompletedTask;
    }
}