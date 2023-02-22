using eShopSolutionV1.Data.EntityFrameworkCore;
using eShopSolutionV1.Service.Catalog.Products.Dtos;
using eShopSolutionV1.Service.Catalog.Products.Dtos.Public;
using eShopSolutionV1.Service.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Service.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopSolutionDbContext _context;
        public PublicProductService(EShopSolutionDbContext context)
        {
            _context = context;
        }

        public async Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            // Select join
            var query = from p in _context.Products
                        join c in _context.ProductCategories on p.ProductCategoryId equals c.Id
                        select p;
            // Filter
            if(request.CategoryId.HasValue && request.CategoryId > 0)
            {
                query = query.Where(p=> p.ProductCategoryId== request.CategoryId);
            }
            {

            }
            // Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(p =>
                new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    OriginalPrice = p.OriginalPrice,
                    Price = p.Price,
                }).ToListAsync();

            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };

            return pageResult;
        }
    }
}
