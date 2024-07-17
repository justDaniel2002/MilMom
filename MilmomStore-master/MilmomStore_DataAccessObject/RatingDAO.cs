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
        if (productId <= 0)
        {
            throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
        }
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
        if (productId <= 0)
        {
            throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
        }
        var entity = await _context.Rating
            .Where(r => r.ProductID == productId)
            .ToListAsync();
        if (entity == null)
        {
            throw new ArgumentNullException($"Entity with id {productId} not found");
        }
        return entity;
    }
    public async Task<IEnumerable<Rating?>> GetRatingByAccountId(string accountId)
    {
        if (string.IsNullOrEmpty(accountId))
        {
            throw new ArgumentException("Account ID is required.", nameof(accountId));
        }
        var entity = await _context.Rating
            .Where(r => r.AccountID == accountId)
            .ToListAsync();
        if(entity == null)
        {
            throw new ArgumentNullException($"Entity with id {accountId} not found");
        }
        return entity;
    }

    public async Task<Rating?> GetRatingByUserIdAndProduct(string accountId, int productId)
    {
        if (string.IsNullOrEmpty(accountId))
        {
            throw new ArgumentException("Account ID is required.", nameof(accountId));
        }
        if (productId <= 0)
        {
            throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
        }
        var entity = await _context.Rating
            .Where(r => r.AccountID == accountId && r.ProductID == productId)
            .FirstOrDefaultAsync();
        if (entity == null)
        {
            throw new ArgumentNullException($"Entity with accountid {accountId}, productId{productId} not found");
        }
        return entity;
    }
}
