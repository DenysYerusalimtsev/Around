using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Around.DataAccess.SqlServer
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DronesharingContext>
    {
        public DronesharingContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                // .SetBasePath(Directory.GetCurrentDirectory())
                // .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DronesharingContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            // builder.UseLazyLoadingProxies();

            return new DronesharingContext(builder.Options);
        }
    }
}
