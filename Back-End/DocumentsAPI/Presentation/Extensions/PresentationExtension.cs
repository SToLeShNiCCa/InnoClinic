namespace Presentation.Extensions
{
    public static class PresentationExtension
    {
        public static IServiceCollection AddPresentation(
            this IServiceCollection services, IConfigurationBuilder configuration)
        {
            return services
                .UseControllers()
                .AddSwagger()
                .AddJsonConf(configuration);
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
            this IServiceCollection services, IConfigurationBuilder configuration)
        {
            configuration
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings{Environment
                    .GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();

            return services;
        }
    }
}
