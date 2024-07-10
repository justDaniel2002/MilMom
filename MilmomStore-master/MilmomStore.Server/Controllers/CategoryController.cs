using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Category;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Service;

namespace MilmomStore.Server.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetAllCategoryResponse>>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoryFromBase();
            return Ok(categories);
        }
        
        [HttpGet]
        [Route("GetCategory/{id}")]
        public async Task<ActionResult<BaseResponse<GetAllCategoryResponse>>> GetCategoryDetailByIdFromBase(int id)
        {
            if(id == 0 || id == null)
            {
                return BadRequest("Please Input Id!");
            }
            return await _categoryService.GetCategoryDetailByIdFromBase(id);
        }

        /*[Authorize(Roles = "Staff")]*/
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<ActionResult<BaseResponse<CreateCategoryRequest>>> CreateProductFromBase([FromBody] CreateCategoryRequest request)
        {
            if (request == null)
            {
                return BadRequest("Please Implement all Information");
            }
            var user = await _categoryService.CreateCategoryFromBase(request);
            return user;
        }

        /*[Authorize(Roles = "Staff")]*/
        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<ActionResult<BaseResponse<UpdateCategoryRequest>>> UpdateCategoryFromBase(int id,
            [FromBody] UpdateCategoryRequest category)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Please Input Id!");
            }
            return await _categoryService.UpdateCategoryFromBase(id, category);
        }

       /* [Authorize(Roles = "Staff, Customer")]*/
        [HttpGet]
        [Route("base/search")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetAllCategoryResponse>>>> GetSearchCategoryFromBase(string search, int pageIndex, int pageSize)
        {
            if (string.IsNullOrEmpty(search) && pageIndex == 0 && pageSize == 0)
            {
                // Check if pageIndex is not a valid integer
                if (!int.TryParse(pageIndex.ToString(), out _))
                {
                    return BadRequest("pageIndex must be a valid integer.");
                }

                // Check if pageSize is not a valid integer
                if (!int.TryParse(pageSize.ToString(), out _))
                {
                    return BadRequest("pageSize must be a valid integer.");
                }

                // Continue with your logic if all conditions are met
                return BadRequest("Please Inplement all information!");
            }
            return await _categoryService.GetSearchCategoryFromBase(search, pageIndex, pageSize);
        }

    }
}
