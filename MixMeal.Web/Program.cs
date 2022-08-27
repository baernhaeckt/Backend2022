using MixMeal.Modules.UserManagement;
using MixMeal.Persistence.PostgreSQL;
using System.Text.Json.Serialization;
using MixMeal.Web;
using MixMeal.Web.Middleware;
using MixMeal.Modules.Recommendations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddControllersAsServices()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgreSQL(builder.Configuration);
builder.Services.AddUserManagement();
builder.Services.AddJwtAuthentication();
builder.Services.AddRecommendation();

var app = builder.Build();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// Used to expose this class to the test project
public partial class Program { }
