using TCSExchangeRateAPI.Infrastructure.Data;
using TCSExchangeRateAPI.Transversal.Common;
using TCSExchangeRateAPI.Transversal.Logging;

namespace TCSExchangeRateAPI.Services.WebAPI.Modules.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}