using Ductus.FluentDocker.Services;
using Ductus.FluentDocker.Services.Extensions;
using System;

namespace MixMeal.Persistence.PostgreSQL.IntegrationTests
{
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
                .WithHostName("rabbitmq")
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
                return $"Host={endpoint.Address};Port={endpoint.Port};Database={PostgreSQLDatabase};Username={PostgreSQLUser};Password={PostgreSQLPassword}";
            }
        }

        public void Dispose()
        {
            Container?.Dispose();
            DbContext?.Dispose();
        }
    }
}