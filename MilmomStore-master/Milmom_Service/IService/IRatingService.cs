using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Rating;
using Milmom_Service.Model.Response.Rating;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.IService;

public interface IRatingService
{
    
    public Task<BaseResponse<RatingResponse>> AddRating(CreateRatingRequest createRating);
    public Task<BaseResponse<RatingResponse>> UpdateRatingAsync(UpdateRatingRequest updateRating);
    public Task<bool> DeleteRatingAsync(int ratingId);
    
    public Task<BaseResponse<IEnumerable<RatingResponse>>> GetRatingByProductId(int productId);
    public Task<BaseResponse<IEnumerable<RatingResponse>>> GetRatingByAccountId(string accountId);
    //public Task<Rating> GetRatingByUserIdAndProduct(string accountId, int productId)
}