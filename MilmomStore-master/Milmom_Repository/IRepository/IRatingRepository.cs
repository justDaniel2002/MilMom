using Milmom_Repository.IBaseRepository;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Repository.IRepository;

public interface IRatingRepository : IBaseRepository<Rating>
{
    public Task<double> GetAverageRating(int productId);
    public Task<IEnumerable<Rating?>> GetRatingByProductId(int productId);
    public Task<IEnumerable<Rating?>> GetRatingByAccountId(string accountId);
    public Task<Rating?> GetRatingByUserIdAndProduct(string accountId, int productId);
}