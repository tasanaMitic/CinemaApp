using CinemaApp.Common.Interfaces;
using CinemaApp.Repositories.Context;
using CinemaApp.Repositories.UnitOfWork;
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
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(serviceProvider => new UnitOfWork(serviceProvider.GetService<CinemaContext>()));

            services.AddScoped<ICinemaHallService>(serviceProvider => new CinemaHallService(serviceProvider.GetService<IUnitOfWork>()));
            services.AddScoped<IFilmService>(serviceProvider => new FilmService(serviceProvider.GetService<IUnitOfWork>()));
            services.AddScoped<IProjectionService>(serviceProvider => new ProjectionService(serviceProvider.GetService<IUnitOfWork>()));
            services.AddScoped<ITicketService>(serviceProvider => new TicketService(serviceProvider.GetService<IUnitOfWork>()));
            services.AddScoped<IUserService>(serviceProvider => new UserService(serviceProvider.GetService<IUnitOfWork>()));

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
