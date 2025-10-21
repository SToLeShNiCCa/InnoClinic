using Infrastructure.DBConfiguration.ServiceContext;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Extension
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseProgramConfiguration(
            this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            return app
                .SwaggerExtension(environment)
                .ProgramConfiguration()
                .UseDatabaseMigrations();
        }

        private static IApplicationBuilder SwaggerExtension(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            return app;
        }

        private static IApplicationBuilder ProgramConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();

            return app;
        }

        private static IApplicationBuilder UseDatabaseMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ServicesContext>();
            db.Database.Migrate();

            return app;
        }
    }
}
