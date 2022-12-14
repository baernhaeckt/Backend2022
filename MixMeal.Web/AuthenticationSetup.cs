using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using MixMeal.Modules.UserManagement.Abstraction;

namespace MixMeal.Web;

public static class AuthenticationSetup
{
    public static void AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            using (IServiceScope scope = services.BuildServiceProvider().CreateScope())
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = scope.ServiceProvider.GetRequiredService<ISecurityKeyProvider>().GetSecurityKey(),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }

            // We have to hook the OnMessageReceived event in order to
            // allow the JWT authentication handler to read the access token from the query string
            // when a WebSocket or Server-Sent Events request comes in.
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    StringValues accessToken = context.Request.Query["access_token"];

                    // If the request is for our hub...
                    PathString path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/newsfeed", StringComparison.OrdinalIgnoreCase))
                    {
                        // Read the token out of the query string
                        context.Token = accessToken;
                    }

                    return Task.CompletedTask;
                }
            };
        });
    }
}
