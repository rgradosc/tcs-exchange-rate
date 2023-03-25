using Microsoft.OpenApi.Models;

namespace TCSExchangeRateAPI.Services.WebAPI.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TCS Technology Services API Exchange Rate",
                    Version = "v1",
                    Description = "Web API built for currency exchange rate conversion with ASP.Net Core",
                    Contact = new OpenApiContact
                    {
                        Email = "grados_2008@hotmail.com",
                        Name = "Néstor Grados",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "General Public License v3",
                        Url = new Uri("https://www.gnulicense.com"),
                    }
                });
            });

            return services;
        }
    }
}
