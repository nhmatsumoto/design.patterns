using Microsoft.EntityFrameworkCore;
using nhmatsumoto.repository.pattern.Context.Interfaces;
using nhmatsumoto.repository.pattern.Context;
using nhmatsumoto.repository.pattern.Controllers;

namespace nhmatsumoto.repository.pattern
{
    public static class Bootstrap
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<WeatherForecastController>();
        }
    }
}
