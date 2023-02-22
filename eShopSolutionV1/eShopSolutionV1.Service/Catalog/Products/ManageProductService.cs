using eShopSolutionV1.Data.EntityFrameworkCore;
using eShopSolutionV1.Model.Models;
using eShopSolutionV1.Service.Catalog.Products.Dtos;
using eShopSolutionV1.Service.Common;
using eShopSolutionV1.Utilities.Exceptions;
using eShopSolutionV1.ViewModel.Catalog.ProductImages.Manage;
using eShopSolutionV1.ViewModel.Catalog.Products.Manage;
using eShopSolutionV1.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutionV1.Service.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopSolutionDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public ManageProductService(EShopSolutionDbContext context, IStorageService storageService) 
        {
            _context = context;
            _storageService = storageService;
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

            if (request.Image != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.Image.Length,
                        ImagePath = await this.SaveFile(request.Image),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
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

            var images = _context.ProductImages.Where(i => i.ProductId == id);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
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
            Product product = await _context.Products.FindAsync(request.Id);

            if (product == null)
            {
                throw new EShopSolutionException("Can not find a product:" + request.Id);
            }

            product.Name = request.Name;

            return await _context.SaveChangesAsync();

        }

        public Task<int> UpdatePrice(int productId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateStock(int productId, int addQuantity)
        {
            throw new NotImplementedException();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public Task<int> AddImage(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new EShopSolutionException($"Cannot find an image with id {imageId}");
            _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
