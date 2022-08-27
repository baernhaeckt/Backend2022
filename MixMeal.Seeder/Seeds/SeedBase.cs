using Microsoft.Extensions.Configuration;
using MixMeal.Core.Models;
using MixMeal.Modules.UserManagement.Abstraction;
using MixMeal.Modules.UserManagement.Security;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace MixMeal.Seeder.Seeds;

public abstract class SeedBase
{
    private RestApiConfiguration _configuration;

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
            JwtSecurityTokenFactory securityTokenFactory = new JwtSecurityTokenFactory(new SymmetricSecurityKeyProvider(LoadConfiguration().SecurityKey));
            string jwt = securityTokenFactory!.Create(Guid.NewGuid(), "admin", Enumerable.Empty<string>());

            return new AuthenticationHeaderValue("Bearer", jwt);
        }
    }


    public abstract Task Seed();

    protected HttpContent AsHttpJsonContent<TEntity>(TEntity entity)
    {
        var myContent = JsonConvert.SerializeObject(entity);
        var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        var httpContent = new ByteArrayContent(buffer);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return httpContent;
    }
}
