using Application.Extension;
using Infrastructure.DBSettings;
using Infrastructure.Extension;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddProgramServices(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAngularApp");

app.AddApplicationSettings(builder.Environment);

app.MapControllers();

app.Run();