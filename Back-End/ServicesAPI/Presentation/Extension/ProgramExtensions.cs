using System.Reflection;

namespace Presentation.Extension
{
    public static class ProgramExtensions
    {
        public static IServiceCollection AddProgramServices(this IServiceCollection service)
        {
            return service
                .ProgramServices();
        }

        private static IServiceCollection ProgramServices(this IServiceCollection service)
        {
            service.AddControllers();
            service.AddOpenApi();
            service.AddSwaggerGen();
            service.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return service;
        }
    }
}
