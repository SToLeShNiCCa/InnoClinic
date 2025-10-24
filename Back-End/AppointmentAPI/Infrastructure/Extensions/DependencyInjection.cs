using Infrastructure.DBSettings.DatabaseSettings;
using Infrastructure.DBSettings.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection service)
        {
            return service.DbConfiguration();
        }

        private static IServiceCollection DbConfiguration(this IServiceCollection service)
        {
            var dbSettings = service.BuildServiceProvider().GetRequiredService<IOptions<DataBaseSettings>>().Value;

            service.AddDbContext<AppointmentDbContext>(p => p.UseNpgsql(dbSettings.ConnectionString));

            return service;
        }
    }
}
