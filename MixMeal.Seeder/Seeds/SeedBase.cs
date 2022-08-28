using Microsoft.Extensions.Configuration;
using MixMeal.Modules.UserManagement.Security;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MixMeal.Seeder.Seeds;

public abstract class SeedBase
{
    private readonly RestApiConfiguration _configuration;

    protected SeedBase()
    {
        _configuration = LoadConfiguration();
    }

    private RestApiConfiguration LoadConfiguration()
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json");
        IConfiguration config = configBuilder.Build();

        return config.GetSection("web").Get<RestApiConfiguration>();
    }

    private HttpClient? _httpClient = null;
    protected HttpClient client
    {
        get
        {
            if (_httpClient != null)
            {
                return _httpClient;
            }

            _httpClient ??= new HttpClient()
            {
                BaseAddress = LoadConfiguration().Uri
            };
            _httpClient.DefaultRequestHeaders.Authorization = AuthorizationHeader;

            return _httpClient;
        }
    }

    private AuthenticationHeaderValue AuthorizationHeader
    {
        get
        {
            JwtSecurityTokenFactory securityTokenFactory = new(new SymmetricSecurityKeyProvider(LoadConfiguration().SecurityKey));
            string jwt = securityTokenFactory!.Create(Guid.NewGuid(), "admin", Enumerable.Empty<string>());

            return new AuthenticationHeaderValue("Bearer", jwt);
        }
    }


    public abstract Task Seed();

    protected HttpContent AsHttpJsonContent<TEntity>(TEntity entity)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());
        var bytes = JsonSerializer.SerializeToUtf8Bytes(entity, options);
        var httpContent = new ByteArrayContent(bytes);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return httpContent;
    }

    protected async Task Post<TEntity>(string path, IEnumerable<TEntity> seedData)
    {
        Console.WriteLine($"Seeding to: {Path.Combine(client.BaseAddress!.ToString(), path)}");
        foreach (TEntity entity in seedData)
        {
            HttpResponseMessage result = await client.PostAsync(path, AsHttpJsonContent(entity));
            Console.WriteLine($"Seed: {result.StatusCode}");
        }
    }
}
