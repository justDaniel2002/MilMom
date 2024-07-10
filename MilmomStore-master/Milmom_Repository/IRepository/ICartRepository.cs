using MilmomStore_BusinessObject.Model;
using Milmom_Repository.IBaseRepository;
namespace Milmom_Repository.IRepository;

public interface ICartRepository : IBaseRepository<Cart>
{
    public Task AddToCart(string accountId, int productId);
    public Task RemoveFromCart(string accountId, int productId);
    public Task<Cart?> GetCart(string accountId);
    public Task ClearCart(string accountId);
    public Task<double> GetAmount(string accountId);
}