using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.IdentityModel;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_DataAccessObject
{
    public class BlogDAO : BaseDAO<Blog>
    {
        private readonly MilmomSystemContext _context;
        public BlogDAO(MilmomSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            return await _context.Blogs
                .Include(b => b.Account)
                .Include(b => b.ImageBlogs)
                .ToListAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
             var entity = await _context.Set<Blog>()
                .Include(b => b.Account)
                .Include(b => b.ImageBlogs)
                .SingleOrDefaultAsync(b => b.BlogID == id);
            if(entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }

        public async Task<IEnumerable<Blog>> SearchBlogsAsync(string search, int pageIndex, int pageSize)
        {
            IQueryable<Blog> searchBlogs = _context.Blogs;

            if (!string.IsNullOrEmpty(search))
            {
                searchBlogs = searchBlogs
                            .Include(b => b.Account)
                            .Include(b => b.ImageBlogs)
                            .Where(b => b.Title.ToLower().Contains(search.ToLower()));
            }

            var result = PaginatedList<Blog>.Create(searchBlogs, pageIndex, pageSize).ToList();
            return result;
        }

        public async Task<bool> DeleteBlog(Blog blog)
        {
            if (blog == null)
            {
                throw new ArgumentNullException(nameof(blog));
            }
            blog.Status = false;
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
