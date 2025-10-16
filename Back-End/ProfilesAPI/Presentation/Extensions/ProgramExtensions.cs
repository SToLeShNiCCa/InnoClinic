using System.Reflection;

namespace Presentation.Extensions
{
    public static class ProgramExtensions
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();
            services.AddSwaggerGen();
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return services;
        }

        public static I
    }
}
