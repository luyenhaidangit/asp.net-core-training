using eShopSolutionV1.Service.Catalog.Products.Dtos;
using eShopSolutionV1.Service.Catalog.Products.Dtos.Public;
using eShopSolutionV1.ViewModel.Catalog.ProductImages.Manage;
using eShopSolutionV1.ViewModel.Catalog.Products.Manage;
using eShopSolutionV1.ViewModel.Common;
using Microsoft.AspNetCore.Http;
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

        //Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

        Task<int> UpdatePrice(int productId, decimal newPrice);

        Task<int> AddViewCount(int productId);

        Task<int> UpdateStock(int productId, int addQuantity);

        Task<int> AddImage(int productId, List<IFormFile> files);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, string caption, bool isDefault);

        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
