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
    public class ImageBlogRepository : BaseRepository<ImageBlog>, IImageBlogRepository
    {
        private readonly ImageBlogDAO _imageBlogDao;
        public ImageBlogRepository(ImageBlogDAO imageBlogDao) : base(imageBlogDao)
        {
           _imageBlogDao = imageBlogDao;
        }

        public async Task<IEnumerable<ImageBlog>> GetAllAsync()
        {
            return await _imageBlogDao.GetAllAsync();
        }

        public async Task<ImageBlog> GetByIdAsync(int id)
        {
            return await _imageBlogDao.GetByIdAsync(id);
        }

        public async Task<ImageBlog> AddAsync(ImageBlog entity)
        {
            return await _imageBlogDao.AddAsync(entity);
        }

        public async Task<ImageBlog> UpdateAsync(ImageBlog entity)
        {
            return await _imageBlogDao.UpdateAsync(entity);
        }

        public async Task<ImageBlog> DeleteAsync(ImageBlog entity)
        {
            return await _imageBlogDao.DeleteAsync(entity);
        }
    }
}
