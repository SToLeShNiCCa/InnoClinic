using Infrastructure.ContextFactory;
using Infrastructure.DBConfiguration.DBSettings;
using Infrastructure.DBConfiguration.ServiceContext;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection service)
        {
            return service
                .ConfigureDatabase()
                .AddRepositories();
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection service)
        {
            var dbSettings = service.BuildServiceProvider().GetRequiredService<DataBaseSettings>();

            service.AddDbContext<ServicesContext>(options => options
                .UseSqlServer
                    (dbSettings.ConnectionString, op => op.MigrationsAssembly(typeof(ServicesContextFactory).Assembly)));

            return service;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IServiceRepository>();
            service.AddScoped<IServiceCategoryRepository>();

            return service;
        }
    }
}
