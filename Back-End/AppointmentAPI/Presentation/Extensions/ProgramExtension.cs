using System.Reflection;

namespace Presentation.Extensions
{
    public static class ProgramExtension
    {
        public static IServiceCollection AddProgramServices(this IServiceCollection services)
        {
            return services
                .ProgramServices();
        }

        private static IServiceCollection ProgramServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();
            services.AddSwaggerGen();
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
