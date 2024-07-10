using Milmom_Service.Model.Response.ImageProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milmom_Service.Model.Request.ImageProduct;

namespace Milmom_Service.Model.Request.Product
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }

        public int InventoryQuantity { get; set; }

        public string Description { get; set; }

        public double UnitPrice { get; set; }

        public double PurchasePrice { get; set; }

        public string Supplier { get; set; }
        public string Original { get; set; }
        public bool Status { get; set; }

        public string Ingredient { get; set; }

        public string Instruction { get; set; }
        public double Weight { get; set; }

        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        
        public ICollection<ProductImage> ImageProducts { get; set;}
    }
}
