using CinemaApp.Common.Interfaces;
using CinemaApp.Services.Services;

namespace CinemaApp.WebApi
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICinemaHallService>(serviceProvider => new CinemaHallService());

            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
