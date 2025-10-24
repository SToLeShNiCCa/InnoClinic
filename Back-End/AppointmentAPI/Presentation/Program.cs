using Infrastructure.DBSettings.DatabaseSettings;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true);

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection(nameof(DataBaseSettings)));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();