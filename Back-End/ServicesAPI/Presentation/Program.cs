using Application;
using Infrastructure;
using Presentation.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true);

builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddProgramServices();

var app = builder.Build();

app.UseProgramConfiguration(app.Environment);

app.MapControllers();

app.Run();