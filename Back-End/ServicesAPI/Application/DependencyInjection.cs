using Application.Services.Implementations;
using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services.AddServices();
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IServiceServices, ServiceServices>()
                .AddScoped<IServiceCategoryServices, ServiceCategoryServices>();

            return services;
        }
    }
}
