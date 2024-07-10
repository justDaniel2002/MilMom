using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Blog;
using Milmom_Service.Model.Request.Report;
using Milmom_Service.Model.Response.Blog;
using Milmom_Service.Model.Response.Report;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.IService
{
    public interface IBlogService
    {
        Task<BaseResponse<IEnumerable<BlogResponse>>> GetAllBlogFromBase();
        Task<BaseResponse<BlogResponse>> GetBlogByIdFromBase(int id);
        Task<BaseResponse<BlogRequest>> CreateBlogFromBase(BlogRequest request);
        Task<BaseResponse<UpdateBlogRequest>> UpdateBlogFromBase(int id, UpdateBlogRequest request);
        Task<Boolean> DeleteBlog(int id);
        Task<BaseResponse<IEnumerable<BlogResponse>>> GetSearchBlogFromBase(string search, int pageIndex, int pageSize);
    }
}
