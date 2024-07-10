using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Model.Response.Rating;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Product
{
    public class GetProductDetailForHP
    {
        public int ProductID { get; set; }
        
        public string Name { get; set; }
        
        public int InventoryQuantity { get; set; }
        
        public string Description { get; set; }
        
        public double UnitPrice { get; set; }
        
        public double PurchasePrice { get; set; }
        
        public string Supplier { get; set; }
        public string Original { get; set; }

        public string Ingredient { get; set; }
        
        public string Instruction { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }

        public ICollection<GetRatingResponse> Ratings { get; set; }
    }
}
