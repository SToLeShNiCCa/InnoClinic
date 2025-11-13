using Infrastructure.BLOBRepository.Interface;
using Infrastructure.BLOBRepository.Implementation;
using Infrastructure.MongoRepository.Implementations;
using Infrastructure.MongoRepository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            return services.AddRepositories();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IBlobRepository, BlobRepository>();

            return services;
        }
    }
}
