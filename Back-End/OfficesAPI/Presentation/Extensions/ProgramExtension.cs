using System.Reflection;

namespace Presentation.Extensions
{
    public static class ProgramExtension
    {
        public static IServiceCollection AddProgramServices(this IServiceCollection services)
        {
            return services.UseProgramSettings();
        }

        private static IServiceCollection UseProgramSettings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services
                .AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddOpenApi();
            services.AddSwaggerGen();

            return services;
        }
    }
}
