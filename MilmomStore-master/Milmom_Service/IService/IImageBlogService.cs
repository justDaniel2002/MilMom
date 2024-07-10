using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.ImageBlog;
using Milmom_Service.Model.Response.ImageProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.IService
{
    public interface IImageBlogService
    {
        Task<BaseResponse<IEnumerable<GetAllImageBlogResponse>>> GetAllImageProductsFromBase();
    }
}
