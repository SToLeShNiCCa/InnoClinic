using Infrastructure.BLOBRepository.Interface;
using Infrastructure.BLOBRepository.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.MongoRepository.Photoes.Implementations;
using Infrastructure.MongoRepository.Photos.Interfaces;

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
