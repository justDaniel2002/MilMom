using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Model.Response.Rating;

namespace Milmom_Service.Model.Response.Product;

public class GetAllProductsResponse
{
    public int ProductID { get; set; }

    public string Name { get; set; }

    public double PurchasePrice { get; set; }

    public bool Status { get; set; }

    public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }

    public GetCategoryResponse Category { get; set; }
    public ICollection<RatingResponse> Ratings { get; set; }
}