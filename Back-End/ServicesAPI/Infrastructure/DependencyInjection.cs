using Infrastructure.DBConfiguration;
using Infrastructure.DBConfiguration.DBSettings;
using Infrastructure.DBConfiguration.ServiceContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection service)
        {
            return service.ConfigureDatabase();
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection service)
        {
            var dbSettings = service.BuildServiceProvider().GetRequiredService<DataBaseSettings>();

            service.AddDbContext<ServicesContext>(options => options
                .UseSqlServer
                    (dbSettings.ConnectionString, op => op.MigrationsAssembly(typeof(ServicesContextFactory).Assembly)));

            return service;
        }
    }
}
