using eShopSolution.Data.Configurations;
using eShopSolutionV1.Data.Configurations;
using eShopSolutionV1.Data.Extensions;
using eShopSolutionV1.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Data.EntityFrameworkCore
{
    public class EShopSolutionDbContext: DbContext
    {
        public EShopSolutionDbContext(DbContextOptions options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Config using Fluent API
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            // Data seeding
            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<AppConfig> AppConfigs { get; set; }
    }
}
