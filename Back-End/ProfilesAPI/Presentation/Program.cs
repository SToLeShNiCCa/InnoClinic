using Application.Services.Implementations;
using Application.Services.Interfaces;
using Infrastructure.DbConfigurations.Contexts;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Migrations.MSSQL;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

/*builder.AddServiceDefaults();*/

builder.Services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDoctorsRepository, DoctorsRepository>();

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientsRepository, PatientsRepository>();

builder.Services.AddScoped<IReceptionistService, ReceptionistService>();
builder.Services.AddScoped<IReceptionistsRepository, ReceptionistsRepository>();

string connection = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new Exception("Connection string not found");

builder.Services.AddDbContext<ProfilesContext>(builder => builder
.UseSqlServer(connection, op => op.MigrationsAssembly(typeof(ProfilesContextFactory).Assembly)));

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
