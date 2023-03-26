namespace TCSExchangeRateAPI.Services.WebAPI.Modules.Features
{
    public static class FeaturesExtensions
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services, IConfiguration configuration)
        {
            // Config Json Options
            services.AddControllers()
                .AddNewtonsoftJson();

            return services;
        }
    }
}
