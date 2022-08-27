using FluentAssertions;
using MixMeal.Core.Models;
using System.Linq;
using Xunit;

namespace MixMeal.Persistence.PostgreSQL.IntegrationTests;

[Collection("PostgreSQL")]
public class PostgreSQLContextFixture
{
    private readonly PostgreSQLFixture postgreSQLFixture;

    public PostgreSQLContextFixture(PostgreSQLFixture postgreSQLFixture)
    {
        this.postgreSQLFixture = postgreSQLFixture;
    }

    [Fact]
    public void Should_ConnectAndCreateEntity()
    {
        postgreSQLFixture.DbContext.Add(new Dish() { Name = "Hannes" });
        postgreSQLFixture.DbContext.SaveChanges();

        var all = postgreSQLFixture.DbContext.Dishes.AsQueryable().Where(it => it.Name == "Hannes").ToList();
    }
}
