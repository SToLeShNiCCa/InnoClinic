using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.DbConfigurations.Contexts;
using Application;
using Infrastructure.DBSettings;
using Presentation.Extensions;
using Application.Localization;

var builder = WebApplication.CreateBuilder(args);

/*builder.AddServiceDefaults();*/
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true);

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection(nameof(DataBaseSettings)));

//builder.Services.BindSettings();

builder.Services.AddPresentation();
builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();

var app = builder.Build();


LangHelper.ChangeLanguage("de");
Console.WriteLine($"{LangHelper.GetString("Doctor")} {LangHelper.GetString("Not Found")}");

/*app.MapDefaultEndpoints();*/

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
