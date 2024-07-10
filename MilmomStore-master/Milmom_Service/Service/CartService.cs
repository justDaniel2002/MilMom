using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.Cart;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Service;

public class CartService : ICartService
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    
    public CartService(ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task AddToCart(string accountId, int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null || product.InventoryQuantity < 1)
        {
            throw new Exception("Product not found or out of stock");
        }

        await _cartRepository.AddToCart(accountId, productId);
    }

    public async Task RemoveFromCart(string accountId, int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null || product.InventoryQuantity < 1)
        {
            throw new Exception("Product not found or out of stock");
        }

        //await _cartRepository.AddToCart(accountId, productId);
        await _cartRepository.RemoveFromCart(accountId, productId);
    }

    public async Task<BaseResponse<CartResponse>> GetCart(string accountId)
    {
        var cart = await _cartRepository.GetCart(accountId);
        var result = _mapper.Map<CartResponse>(cart);
        return new BaseResponse<CartResponse>("Get cart success", StatusCodeEnum.OK_200, result);
    }

    public async Task<double> GetAmount(string accountId)
    {
        return await _cartRepository.GetAmount(accountId);
    }

    public async Task ClearCart(string accountId)
    {
        await _cartRepository.ClearCart(accountId);
    }

    public async Task<BaseResponse<CartResponse>> UpdateProductQuantityInCart(string accountId, int productId, int newQuantity)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null || product.InventoryQuantity < 1)
        {
            throw new Exception("Product not found or out of stock");
        }

        var cart = await _cartRepository.GetCart(accountId);
        var cartItem = cart?.CartItem.FirstOrDefault(ci => ci.ProductID == productId);
        if (cartItem == null)
        {
            throw new Exception("Product not found in cart");
        }

        if (newQuantity < 1)
        {
            throw new Exception("Quantity must be greater than 0");
        }

        cartItem.Quantity = newQuantity;
        await _cartRepository.UpdateAsync(cart);
        var result = _mapper.Map<CartResponse>(cart);
        return new BaseResponse<CartResponse>("Update product quantity in cart success", StatusCodeEnum.OK_200, result);
    }
}