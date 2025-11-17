using Application.BlobCQ.BlobPhotoCQ.Command;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services
                .AddMediatR();
        }
        private static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AzureUploadPhotoCommand).Assembly));

            return services;
        }
    }
}
