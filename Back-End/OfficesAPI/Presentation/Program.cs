using Application.Services.Implementation;
using Application.Services.Interface;
using Infrastructure.DBSettings;
using Infrastructure.Repository.Implementation;
using Infrastructure.Repository.Interface;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
builder.Services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IOfficeService, OfficeService>();

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
