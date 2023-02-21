using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Data.EntityFrameworkCore
{
    public class EShopSolutionDbContextFactory : IDesignTimeDbContextFactory<EShopSolutionDbContext>
    {
        public EShopSolutionDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("eShopSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<EShopSolutionDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EShopSolutionDbContext(optionsBuilder.Options);
        }
    }
}
