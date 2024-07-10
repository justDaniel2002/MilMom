using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Model.Response.Rating;
using Milmom_Service.Model.Response.Report;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Product
{
    public class GetFilterProductForManager
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        public int InventoryQuantity { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public string Supplier { get; set; }
        public string Original { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Status { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Ingredient { get; set; }
        //add more
        public string Instruction { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public ICollection<GetAllImageProductsResponse> ImageProducts { get; set;}
        public GetCategoryResponse Category { get; set; }
        public ICollection<RatingResponse> Ratings { get; set; }
        public double AverageRating { get; set; }
        
    }
}
