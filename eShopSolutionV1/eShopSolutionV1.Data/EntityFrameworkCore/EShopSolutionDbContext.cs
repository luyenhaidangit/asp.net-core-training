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

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
