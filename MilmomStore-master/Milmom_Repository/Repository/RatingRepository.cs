using Milmom_Repository.BaseRepository;
using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using MilmomStore_DataAccessObject.BaseDAO;

namespace Milmom_Repository.Repository;

public class RatingRepository : BaseRepository<Rating>, IRatingRepository
{
    private readonly RatingDAO _ratingDao;
    public RatingRepository(RatingDAO ratingDao) : base(ratingDao)
    {
        _ratingDao = ratingDao;
    }

    public Task<double> GetAverageRating(int productId)
    {
        return _ratingDao.GetAverageRating(productId);
    }

    public async Task<IEnumerable<Rating?>> GetRatingByProductId(int productId)
    {
        return await _ratingDao.GetRatingByProductId(productId);
    }

    public async Task<IEnumerable<Rating?>> GetRatingByAccountId(string accountId)
    {
        return await _ratingDao.GetRatingByAccountId(accountId);
    }

    public async Task<Rating?> GetRatingByUserIdAndProduct(string accountId, int productId)
    {
        return await _ratingDao.GetRatingByUserIdAndProduct(accountId, productId);
    }
}