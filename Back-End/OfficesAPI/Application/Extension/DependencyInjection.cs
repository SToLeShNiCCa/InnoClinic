using Application.Services.Implementation;
using Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services.AddServices();
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOfficeService, OfficeService>();

            return services;
        }
    }
}
