using eShopSolutionV1.Service.Catalog.Products.Dtos;
using eShopSolutionV1.Service.Catalog.Products.Dtos.Public;
using eShopSolutionV1.ViewModel.Catalog.Products.Manage;
using eShopSolutionV1.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Service.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
