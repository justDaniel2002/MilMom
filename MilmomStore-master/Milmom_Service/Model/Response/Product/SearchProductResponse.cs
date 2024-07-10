namespace Milmom_Service.Model.Response.Product;

public class SearchProductResponse
{
    
    public IEnumerable<GetFilterProductForManager> Products { get; set; }
    public int TotalPages { get; set; }
}