using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using Milmom_Repository.BaseRepository;
namespace Milmom_Repository.Repository;

public class CartRepository : BaseRepository<Cart>,ICartRepository
{
    public readonly CartDAO _cartDAO;
    public CartRepository(CartDAO cartDAO) : base(cartDAO)
    {
        _cartDAO = cartDAO;
    }

    public async Task AddToCart(string accountId, int productId)
    {
         await _cartDAO.AddToCart(accountId, productId);
    }

    public async Task RemoveFromCart(string accountId, int productId)
    {
        await _cartDAO.RemoveFromCart(accountId, productId);
    }

    public async Task<Cart?> GetCart(string accountId)
    {
        return await _cartDAO.GetCart(accountId);
    }

    public async Task ClearCart(string accountId)
    {
        await _cartDAO.ClearCart(accountId);
    }

    public async Task<double> GetAmount(string accountId)
    {
        return await _cartDAO.GetAmount(accountId);
    }
}