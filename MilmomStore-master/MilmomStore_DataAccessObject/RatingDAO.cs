using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;

namespace MilmomStore_DataAccessObject;

public class RatingDAO : BaseDAO<Rating>
{
    private readonly MilmomSystemContext _context;
    public RatingDAO(MilmomSystemContext context) : base(context)
    {
        _context = context;
    }
    
    //get avaerage rating of product
    public async Task<double> GetAverageRating(int productId)
    {
        var ratings = await _context.Rating
            .Where(r => r.ProductID == productId)
            .ToListAsync();

        if (ratings.Count == 0)
        {
            return 0;
        }

        var sum = ratings.Sum(r => r.Rate);
        var average = (double)sum / ratings.Count;

        return average;
    }
    public async Task<IEnumerable<Rating?>> GetRatingByProductId(int productId)
    {
        return await _context.Rating
            .Where(r => r.ProductID == productId)
            .ToListAsync();
    }
    public async Task<IEnumerable<Rating?>> GetRatingByAccountId(string accountId)
    {
        return await _context.Rating
            .Where(r => r.AccountID == accountId)
            .ToListAsync();
    }

    public async Task<Rating?> GetRatingByUserIdAndProduct(string accountId, int productId)
    {
        return await _context.Rating
            .Where(r => r.AccountID == accountId && r.ProductID == productId)
            .FirstOrDefaultAsync();
    }
}
