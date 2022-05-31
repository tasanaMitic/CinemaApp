using CinemaApp.Common.Interfaces;
using CinemaApp.Repositories.Context;
using CinemaApp.Services.Services;
using Microsoft.EntityFrameworkCore;

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
            services.AddDbContext<CinemaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));
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
