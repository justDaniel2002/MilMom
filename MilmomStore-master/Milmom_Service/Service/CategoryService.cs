using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Category;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepoitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepoitory;
        }

        public async Task<BaseResponse<CreateCategoryRequest>> CreateCategoryFromBase(CreateCategoryRequest categoryRequest)
        {
            Category category = _mapper.Map<Category>(categoryRequest);
            await _categoryRepository.AddAsync(category);

            var response = _mapper.Map<CreateCategoryRequest>(category);
            return new BaseResponse<CreateCategoryRequest>("Create category as base success", StatusCodeEnum.Created_201, response);
        }

        public async Task<BaseResponse<IEnumerable<GetAllCategoryResponse>>> GetAllCategoryFromBase()
        {

            IEnumerable<Category> category = await  _categoryRepository.GetAllAsync();
            if(category == null)
            {
                return new BaseResponse<IEnumerable<GetAllCategoryResponse>>("Something went wrong!",
                StatusCodeEnum.BadGateway_502, null);
            }
            var categories = _mapper.Map<IEnumerable<GetAllCategoryResponse>>(category);
            if(categories == null)
            {
                return new BaseResponse<IEnumerable<GetAllCategoryResponse>>("Something went wrong!",
                StatusCodeEnum.BadGateway_502, null);
            }
            return new BaseResponse<IEnumerable<GetAllCategoryResponse>>("Get all category as base success",
                StatusCodeEnum.OK_200, categories);
        }

        public async Task<BaseResponse<GetAllCategoryResponse>> GetCategoryDetailByIdFromBase(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetAllCategoryResponse>(category);
            return new BaseResponse<GetAllCategoryResponse>("Get product details success", StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<IEnumerable<GetAllCategoryResponse>>> GetSearchCategoryFromBase(string search, int pageIndex, int pageSize)
        {
            IEnumerable<Category> categories = await _categoryRepository.SearchCategoryAsync(search, pageIndex, pageSize);
            var category = _mapper.Map<IEnumerable<GetAllCategoryResponse>>(categories);
            return new BaseResponse<IEnumerable<GetAllCategoryResponse>>("Get search product as base success",
                StatusCodeEnum.OK_200, category);
        }

        public async Task<BaseResponse<UpdateCategoryRequest>> UpdateCategoryFromBase(int id, UpdateCategoryRequest categoryRequest)
        {
            Category categoryExist = await _categoryRepository.GetByIdAsync(id);
            _mapper.Map(categoryRequest, categoryExist);
            await _categoryRepository.UpdateAsync(categoryExist);

            var result = _mapper.Map<UpdateCategoryRequest>(categoryExist);
            return new BaseResponse<UpdateCategoryRequest>("Update Category as base success", StatusCodeEnum.OK_200, result);
        }
    }
}
