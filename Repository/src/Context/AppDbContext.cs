using Microsoft.EntityFrameworkCore;
using nhmatsumoto.repository.pattern.Context.Entities;

namespace nhmatsumoto.repository.pattern.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<WeatherForecast> WeatherForecast { get; set; }

    }
}
