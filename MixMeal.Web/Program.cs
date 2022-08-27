using MixMeal.Modules.UserManagement;
using MixMeal.Persistence.PostgreSQL;
using MixMeal.Web;
using MixMeal.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddControllersAsServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgreSQL(builder.Configuration);
builder.Services.AddUserManagement();
builder.Services.AddJwtAuthentication();

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
