using Milmom_Repository.BaseRepository;
using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ProductDAO _productDao;
        public ProductRepository(ProductDAO productDao) : base(productDao)
        {
            _productDao = productDao;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productDao.GetAllOrdersAsync();
        }
        
        public async Task<IEnumerable<Product>> GetProductsAsync(string? search, double? lowPrice, double? highPrice, int? category, string sortBy, int pageIndex,
            int pageSize)
        {
            return await _productDao.GetProductsAsync(search, lowPrice, highPrice, category, sortBy, pageIndex, pageSize);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productDao.GetProductByIdAsync(id);
        }

        public async Task<Product> AddAsync(Product entity)
        {
            return await _productDao.AddAsync(entity);
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            return await _productDao.UpdateAsync(entity);
        }

        public async Task<Product> DeleteAsync(Product entity)
        {
            return await _productDao.DeleteAsync(entity);
        }
        public async Task<bool> DeleteTest(Product product)
        {
            return await _productDao.DeleteTest(product);
        }

        public async Task<List<(string ProductName, int QuantitySold)>> GetTopProductsSoldInMonthAsync(int top)
        {
            return await _productDao.GetTopProductsSoldInMonthAsync(top);
        }

        public async Task<IEnumerable<Product>> SearchProductAsync(string? search, int pageIndex, int pageSize)
        {
            return await _productDao.SearchProductAsync(search, pageIndex, pageSize);
        }

        public  int GetTotalPagesAsync(string search, List<Product> products, int pageSize)
        {
            return  _productDao.GetTotalPagesAsync(search,products, pageSize);
        }
    }
}
