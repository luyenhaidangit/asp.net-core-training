using eShopSolutionV1.Service.Catalog.Products.Dtos;
using eShopSolutionV1.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Service.Catalog.Products
{
    public interface IPublicProductService
    {
        PageViewModel<ProductViewModel> GetAllByCategoryId(int categoryId,int pageIndex,int pageSize);
    }
}
