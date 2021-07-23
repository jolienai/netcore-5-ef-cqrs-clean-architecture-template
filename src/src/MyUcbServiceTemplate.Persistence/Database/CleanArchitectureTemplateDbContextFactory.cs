using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace CleanArchitectureTemplate.Persistence.Database
{
    public class CleanArchitectureTemplateDbContextFactory : IDesignTimeDbContextFactory<CleanArchitectureTemplateDbContext>
    {
        public CleanArchitectureTemplateDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CleanArchitectureTemplateDbContext>();

            var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION") ??
                                   throw new Exception("DATABASE_CONNECTION env variable cannot be null");

            optionsBuilder.UseSqlServer(connectionString);

            return new CleanArchitectureTemplateDbContext(optionsBuilder.Options);
        }
    }
}
