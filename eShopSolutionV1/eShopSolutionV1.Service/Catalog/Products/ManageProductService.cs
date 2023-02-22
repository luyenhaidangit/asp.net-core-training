using eShopSolutionV1.Data.EntityFrameworkCore;
using eShopSolutionV1.Model.Models;
using eShopSolutionV1.Service.Catalog.Products.Dtos;
using eShopSolutionV1.Service.Catalog.Products.Dtos.Manage;
using eShopSolutionV1.Service.Dtos;
using eShopSolutionV1.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Service.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopSolutionDbContext _context;
        public ManageProductService(EShopSolutionDbContext context) 
        {
            _context = context;
        }

        public async Task<int> AddViewCount(int productId)
        {
            Product product = await _context.Products.FindAsync(productId);

            product.ViewCount += 1;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            Product product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated= DateTime.Now,
                //ProductTranslations = new List<ProductTranslation>()
                //{
                //    new ProductTranslation()
                //    {
                //        Name = request.Name,
                //        DescriptionAttribute = request.Description,
                //    }
                //}
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new EShopSolutionException("Can not find a product:" + id);
            }

            _context.Products.Remove(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            // Select join
            var query = from p in _context.Products
                        join c in _context.ProductCategories on p.ProductCategoryId equals c.Id
                        select p;
            // Filter
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.Name.Contains(request.KeyWord));
            }

            if(request.CategoryIds.Count> 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.ProductCategoryId));
            }
            // Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(p=>
                new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    OriginalPrice= p.OriginalPrice,
                    Price= p.Price,
                }).ToListAsync();

            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecord= totalRow,
                Items = data,
            };

            return pageResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePrice(int productId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateStock(int productId, int addQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
