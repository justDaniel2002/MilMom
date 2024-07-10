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
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        public readonly BlogDAO _blogDAO;
        public BlogRepository(BlogDAO blogDAO) : base(blogDAO)
        {
            _blogDAO = blogDAO;
        }

        public Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            return _blogDAO.GetAllBlogsAsync();
        }

        public Task<Blog> GetBlogByIdAsync(int id)
        {
            return _blogDAO.GetBlogByIdAsync(id);
        }

        public Task<IEnumerable<Blog>> SearchBlogsAsync(string search, int pageIndex, int pageSize)
        {
            return _blogDAO.SearchBlogsAsync(search, pageIndex, pageSize);
        }

        public async Task<Blog> AddAsync(Blog entity)
        {
            return await _blogDAO.AddAsync(entity);
        }

        public async Task<Blog> UpdateAsync(Blog entity)
        {
            return await _blogDAO.UpdateAsync(entity);
        }

        public async Task<bool> DeleteBlog(Blog blog)
        {
            return await _blogDAO.DeleteBlog(blog);
        }
    }
}
