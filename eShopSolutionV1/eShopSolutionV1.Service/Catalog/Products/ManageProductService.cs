using eShopSolutionV1.Data.EntityFrameworkCore;
using eShopSolutionV1.Model.Models;
using eShopSolutionV1.Service.Catalog.Products.Dtos;
using eShopSolutionV1.Service.Dtos;
using System;
using System.Collections.Generic;
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

        public async Task<int> Create(ProductCreateRequest request)
        {
            Product product = new Product()
            {
                Price = request.Price,
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PageViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
