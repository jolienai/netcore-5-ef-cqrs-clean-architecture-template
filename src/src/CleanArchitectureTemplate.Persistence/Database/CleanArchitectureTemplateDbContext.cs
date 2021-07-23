using Microsoft.EntityFrameworkCore;
using CleanArchitectureTemplate.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Persistence.Database
{
    public class CleanArchitectureTemplateDbContext : DbContext, Application.Interfaces.ICleanArchitectureTemplateDbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public CleanArchitectureTemplateDbContext(DbContextOptions<CleanArchitectureTemplateDbContext> options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchitectureTemplateDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
