using TCSExchangeRateAPI.Transversal.Mapper;

namespace TCSExchangeRateAPI.Services.WebAPI.Modules.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new AutoMapperProfile()));

            return services;
        }
    }
}
