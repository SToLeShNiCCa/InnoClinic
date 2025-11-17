using Infrastructure.BLOBRepository.Interface;
using Infrastructure.BLOBRepository.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.MongoRepository.Photos.Interfaces;
using Infrastructure.MongoRepository.Photos.Implementations;
using Infrastructure.MongoRepository.Results.Interfaces;
using Infrastructure.MongoRepository.Results.Implementations;

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

            services.AddScoped<IResultRepository, ResultRepository>();

            return services;
        }
    }
}
