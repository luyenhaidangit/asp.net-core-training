using eShopSolutionV1.Service.Catalog.Products.Dtos;
using eShopSolutionV1.Service.Catalog.Products.Dtos.Manage;
using eShopSolutionV1.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Service.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int id);

        Task<List<ProductViewModel>> GetAll();

        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

        Task<int> UpdatePrice(int productId, decimal newPrice);

        Task<int> AddViewCount(int productId);

        Task<int> UpdateStock(int productId, int addQuantity);
    }
}
