using Milmom_Service.Model.Response.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Category
{
    public class GetAllCategoryResponse
    {
        
        public int CategoryID { get; set; }
        
        public string Name { get; set; }
        //
        public ICollection<GetAllProductsResponse> Products { get; set; }
    }
}
