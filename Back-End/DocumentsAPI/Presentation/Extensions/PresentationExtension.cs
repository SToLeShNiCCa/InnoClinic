using Infrastructure.DbSettings;

namespace Presentation.Extensions
{
    public static class PresentationExtension
    {
        public static IServiceCollection AddPresentation(
            this IServiceCollection services, IConfigurationBuilder configurationBuilder, IConfiguration configuration)
        {
            return services
                .UseControllers()
                .AddSwagger()
                .AddJsonConf(configurationBuilder)
                .AddDbSettings(configuration);
        }

        private static IServiceCollection UseControllers(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        private static IServiceCollection AddJsonConf(
            this IServiceCollection services, IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings{Environment
                    .GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();

            return services;
        }

        private static IServiceCollection AddDbSettings(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PhotosMongoDatabaseSettings>(configuration.GetSection("PhotosDatabaseSettings"));
            services.Configure<ResultsMongoDatabaseSettings>(configuration.GetSection("ResultsDatabaseSettings"));
            services.Configure<DocumentsMongoDatabaseSettings>(configuration.GetSection("DocumentsDatabaseSettings"));

            return services;
        }
    }
}
