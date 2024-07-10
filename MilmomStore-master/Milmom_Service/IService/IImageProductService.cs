using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Model.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.IService
{
    public interface IImageProductService
    {
        Task<BaseResponse<IEnumerable<GetAllImageProductsResponse>>> GetAllImageProductsFromBase();
        
    }
}
