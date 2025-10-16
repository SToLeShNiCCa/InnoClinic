using Infrastructure.DbConfigurations.Contexts;
using Infrastructure.DBSettings;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .ConfigureRepositories()
            .ConfigureDatabase(configuration);
    }

    private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReceptionistsRepository, ReceptionistsRepository>();
        services.AddScoped<IDoctorsRepository, DoctorsRepository>();
        services.AddScoped<IPatientsRepository, PatientsRepository>();
        
        return services;
    }

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var dbSettings = services.BuildServiceProvider().GetRequiredService<DataBaseSettings>();

        services.AddDbContext<ProfilesContext>(builder => builder
               .UseSqlServer(dbSettings.ConnectionString, op => op.MigrationsAssembly(typeof(ProfilesContextFactory).Assembly)));//move factory

        return services;
    }
}
