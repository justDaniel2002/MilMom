namespace Milmom_Service.Model.Response.Cart;

public class CartResponse
{
    public string AccountID { get; set; }
    public ICollection<CartItemResponse> CartItem { get; set; }
}