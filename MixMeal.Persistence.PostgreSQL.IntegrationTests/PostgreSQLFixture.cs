using Ductus.FluentDocker.Services;
using Ductus.FluentDocker.Services.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MixMeal.Persistence.PostgreSQL.IntegrationTests;

public sealed class PostgreSQLFixture : IDisposable
{
    private IContainerService Container { get; init; }

    public const int PostgreSQLPort = 5432;

    public const string PostgreSQLUser = "mixmeal_dbuser";

    public const string PostgreSQLPassword = "mixmeal_dbpw";

    public const string PostgreSQLDatabase = "mixmeal";

    public MixMealDbContext DbContext { get; init; }

    public PostgreSQLFixture()
    {
        Container = new Ductus.FluentDocker.Builders.Builder()
            .UseContainer()
            .UseImage("postgres")
            .WithHostName("postgres")
            .WithEnvironment($"POSTGRES_USER={PostgreSQLUser}", $"POSTGRES_PASSWORD={PostgreSQLPassword}", $"POSTGRES_DB={PostgreSQLDatabase}")
            .ExposePort(PostgreSQLPort)
            .WaitForMessageInLog("database system is ready to accept connections")
            .Build()
            .Start();

        DbContext = new MixMealDbContext(ConnectionString);
    }

    public string ConnectionString
    {
        get
        {
            var endpoint = Container.ToHostExposedEndpoint($"{PostgreSQLPort}/tcp");
            return $"Host=localhost;Port={endpoint.Port};Database={PostgreSQLDatabase};Username={PostgreSQLUser};Password={PostgreSQLPassword}";
        }
    }

    public void OverwriteConnectionString(IWebHostBuilder builder)
    {
        var testConfigurationSettings = new Dictionary<string, string>
        {
            { "ConnectionStrings:MixMealDBContext", ConnectionString }
        };

        var testConfiguration = new ConfigurationBuilder()
            .AddInMemoryCollection(testConfigurationSettings)
            .Build();

        builder.UseConfiguration(testConfiguration);
    }

    public void Dispose()
    {
        Container?.Dispose();
        DbContext?.Dispose();
    }
}