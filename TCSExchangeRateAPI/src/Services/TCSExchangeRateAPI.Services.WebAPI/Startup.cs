using TCSExchangeRateAPI.Services.WebAPI.Modules.Swagger;
using TCSExchangeRateAPI.Services.WebAPI.Modules.AutoMapper;
using TCSExchangeRateAPI.Services.WebAPI.Modules.DependencyInjection;

namespace TCSExchangeRateAPI.Services.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddDependencyInjection(Configuration);
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Exchange Rate API v1");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
