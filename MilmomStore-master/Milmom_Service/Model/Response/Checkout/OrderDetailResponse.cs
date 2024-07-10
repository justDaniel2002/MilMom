
using Milmom_Service.Model.Response.Product;
namespace Milmom_Service.Model.Response.Checkout;

public class OrderDetailResponse
{
    public int Quantity { get; set; }
    public double unitPrice { get; set; }
    public double TotalAmount { get; set; }
    public GetAllProductsResponse Product { get; set; }
}