using Application.Extension;
using Infrastructure.DBConfiguration.DBSettings;
using Infrastructure.Extension;
using Presentation.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
    .Build();

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection(nameof(DataBaseSettings)));

/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});*/

builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddProgramServices(builder.Configuration);

var app = builder.Build();

//app.UseCors("AllowAngularApp");

app.UseProgramConfiguration(app.Environment);

app.MapControllers();

app.Run();