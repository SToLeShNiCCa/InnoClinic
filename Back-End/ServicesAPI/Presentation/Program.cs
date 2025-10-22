using Application.Extension;
using Infrastructure.DBConfiguration.DBSettings;
using Infrastructure.Extension;
using Presentation.Extension;
using Presentation.Shared.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
    .Build();

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection(nameof(DataBaseSettings)));

builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddProgramServices();

var app = builder.Build();

app.UseProgramConfiguration(app.Environment);

app.MapControllers();

app.Run();