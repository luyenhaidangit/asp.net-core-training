using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Service.Catalog.Products.Dtos
{
    public class ProductViewModel
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public decimal Price { set; get; }

        public decimal OriginalPrice { set; get; }

        public int Stock { set; get; }
    }
}
