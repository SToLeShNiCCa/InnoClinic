using Application.Services.Implementations;
using Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Migrations.MSSQL;
using System.Reflection;
using Infrastructure;
using Infrastructure.DbConfigurations.Contexts;
using Application;
using Infrastructure.DBSettings;
using Microsoft.Extensions.Options;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

/*builder.AddServiceDefaults();*/
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("APSNET_Environment")}.json"); // check variable

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection(nameof(DataBaseSettings)));

builder.Services.BindSettings();

builder.Services.AddPresentation();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

var app = builder.Build();

/*app.MapDefaultEndpoints();*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProfilesContext>();
    db.Database.Migrate();
}

    //app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
