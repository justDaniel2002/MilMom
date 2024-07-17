using Milmom_Repository.BaseRepository;
using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly CategoryDAO _categoryDAO;
        public CategoryRepository(CategoryDAO categoryDAO) : base(categoryDAO) 
        {
            _categoryDAO = categoryDAO;
        }

        public Task<Category> AddAsync(Category entity)
        {
            return _categoryDAO.AddAsync(entity);
        }

        public Task<Category> DeleteAsync(Category entity)
        {
           return _categoryDAO.DeleteAsync(entity);
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return _categoryDAO.GetAllAsync();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            return _categoryDAO.GetByIdAsync(id);
        }

        public Task<IEnumerable<Category>> SearchCategoryAsync(string? search, int pageIndex, int pageSize)
        {
            return _categoryDAO.SearchCategoryAsync(search, pageIndex, pageSize);
        }

        /*public Task<Category> GetByStringId(string id)
        {
            throw new NotImplementedException();
        }*/

        public Task<Category> UpdateAsync(Category entity)
        {
            return _categoryDAO.UpdateAsync(entity);
        }
    }
}
