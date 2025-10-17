using Infrastructure.DbConfigurations.Contexts;
using Infrastructure.DBContextFactory;
using Infrastructure.DBSettings;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        return services
            .ConfigureRepositories()
            .ConfigureDatabase();
    }

    private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReceptionistsRepository, ReceptionistsRepository>();
        services.AddScoped<IDoctorsRepository, DoctorsRepository>();
        services.AddScoped<IPatientsRepository, PatientsRepository>();
        
        return services;
    }

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services)
    {
        var dbSettings = services.BuildServiceProvider().GetRequiredService<DataBaseSettings>();

        services.AddDbContext<ProfilesContext>(builder => builder
               .UseSqlServer(dbSettings.ConnectionString, op => op.MigrationsAssembly(typeof(ProfilesContextFactory).Assembly)));

        return services;
    }
}
