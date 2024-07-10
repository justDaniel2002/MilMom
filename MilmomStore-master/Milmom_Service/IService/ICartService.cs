using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.Cart;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.IService;

public interface ICartService
{
    public Task AddToCart(string accountId, int productId);

    public Task RemoveFromCart(string accountId, int productId);
    
    public Task<BaseResponse<CartResponse>> GetCart(string accountId);
    
    public Task ClearCart(string accountId);
    
    public Task<BaseResponse<CartResponse>> UpdateProductQuantityInCart(string accountId, int productId, int newQuantity);
}