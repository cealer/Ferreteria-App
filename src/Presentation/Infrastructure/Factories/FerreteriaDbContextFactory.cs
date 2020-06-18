using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Presentation.Infrastructure.Factories
{
    public class FerreteriaDbContextFactory : IDesignTimeDbContextFactory<FerreteriaContext>
    {
        public FerreteriaContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<FerreteriaContext>();

            optionsBuilder.UseMySql(config["ConnectionString"], o => o.MigrationsAssembly("Presentation"));

            return new FerreteriaContext(optionsBuilder.Options);
        }
    }

}
