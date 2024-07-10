using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Category;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.IService
{
    public interface ICategoryService
    {
        Task<BaseResponse<IEnumerable<GetAllCategoryResponse>>> GetAllCategoryFromBase();
        Task<BaseResponse<GetAllCategoryResponse>> GetCategoryDetailByIdFromBase(int id);
        Task<BaseResponse<UpdateCategoryRequest>> UpdateCategoryFromBase(int id, UpdateCategoryRequest categoryRequest);
        Task<BaseResponse<CreateCategoryRequest>> CreateCategoryFromBase( CreateCategoryRequest categoryRequest);
        Task<BaseResponse<IEnumerable<GetAllCategoryResponse>>> GetSearchCategoryFromBase(string search, int pageIndex, int pageSize);
    }
}
