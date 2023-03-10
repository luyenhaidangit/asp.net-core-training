using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.ViewModel.Catalog.Products.Manage
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SeoDescription { get; set; }

        public string SeoTitle { get; set; }

        public string SeoAlias { get; set; }

        public IFormFile Image { set; get; }
    }
}
