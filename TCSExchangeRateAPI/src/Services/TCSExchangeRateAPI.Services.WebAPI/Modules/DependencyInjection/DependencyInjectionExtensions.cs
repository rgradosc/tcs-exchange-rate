using TCSExchangeRateAPI.Application.Interfaces;
using TCSExchangeRateAPI.Application.Main;
using TCSExchangeRateAPI.Domain.Interfaces;
using TCSExchangeRateAPI.Domain.Core;
using TCSExchangeRateAPI.Infrastructure.Data;
using TCSExchangeRateAPI.Infrastructure.Interfaces;
using TCSExchangeRateAPI.Infrastructure.Repository;
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

            services.AddScoped<ISymbolApplication, SymbolApplication>();

            services.AddScoped<ISymbolDomain, SymbolDomain>();

            services.AddScoped<ISymbolRepository, SymbolRepository>();

            services.AddScoped<IExchangeRateApplication, ExchangeRateApplication>();

            services.AddScoped<IExchangeRateDomain, ExchangeRateDomain>();

            services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();

            services.AddScoped<IUserApplication, UserApplication>();

            services.AddScoped<IUserDomain, UserDomain>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}