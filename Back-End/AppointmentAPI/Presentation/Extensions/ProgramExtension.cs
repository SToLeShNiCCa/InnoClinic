using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Presentation.Extensions
{
    public static class ProgramExtension
    {
        public static IServiceCollection AddProgramServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .ProgramServices()
                .AddSwaggerGenWithAuth(configuration);
        }

        private static IServiceCollection ProgramServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();
            services.AddSwaggerGen();
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return services;
        }

        private static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSwaggerGen(o =>
            {
                o.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

                o.AddSecurityDefinition("KeyCloak", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(configuration["KeyCloak:AuthorizationUrl"]!),
                            Scopes = new Dictionary<string, string>
                    {
                        { "openid", "openid"},
                        { "profile", "profile"}
                    }
                        }
                    }
                });
                var securityRequirement = new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "KeyCloak"
                    },
                    In = ParameterLocation.Header,
                    Name = "Bearer",
                    Scheme = "Bearer"
                },[]
            }
        };
                o.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
    }
}
