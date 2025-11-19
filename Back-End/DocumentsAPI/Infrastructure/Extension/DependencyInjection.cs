using Microsoft.Extensions.DependencyInjection;
using Infrastructure.MongoRepository.Photos.Interfaces;
using Infrastructure.MongoRepository.Photos.Implementations;
using Infrastructure.MongoRepository.Results.Interfaces;
using Infrastructure.MongoRepository.Results.Implementations;
using Infrastructure.PDFGenerator.Interface;
using Infrastructure.BLOBRepository.Interface;
using Infrastructure.BLOBRepository.Implementation;
using Infrastructure.MongoRepository.Documents.Interface;
using Infrastructure.MongoRepository.Documents.Implementation;

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
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IBlobRepository, BlobPhotoRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IPDFGenerator, PDFGenerator.Implementation.PDFGenerator>();

            return services;
        }
    }
}
