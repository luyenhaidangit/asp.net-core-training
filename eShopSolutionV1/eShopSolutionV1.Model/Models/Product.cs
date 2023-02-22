using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Model.Models
{
    public class Product
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public decimal Price { set; get; }

        public decimal OriginalPrice { set; get; }

        public int Stock { set; get; }

        public int ViewCount { set; get; }

        public DateTime DateCreated { set; get; }

        public int ProductCategoryId { set; get; }

        public ProductCategory ProductCategory { set; get; }
    }
}
