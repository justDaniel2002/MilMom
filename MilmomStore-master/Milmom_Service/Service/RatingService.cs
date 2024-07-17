
using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Rating;
using Milmom_Service.Model.Response.Rating;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Service;

public class RatingService : IRatingService
{
    private readonly IMapper _mapper;
    private readonly IRatingRepository _ratingRepository;
    private readonly IOrderRepository _orderRepository;
    public RatingService(IRatingRepository ratingRepository, IOrderRepository orderRepository, IMapper mapper)
    {
        _ratingRepository = ratingRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    
    public async Task<BaseResponse<RatingResponse>> AddRating(CreateRatingRequest createRating)
    {
        // Check if the user has already rated this product
        var existingRating = await _ratingRepository.GetRatingByUserIdAndProduct(createRating.AccountID, createRating.ProductID);
        if (existingRating != null)
        {
            return new BaseResponse<RatingResponse>
            (
                "User has already rated this product",
                StatusCodeEnum.BadRequest_400,
                null
            );
        }
        if (!await _orderRepository.HasPurchasedProductAsync(createRating.AccountID, createRating.ProductID))
        {
            return new BaseResponse<RatingResponse>
            (
                "User has not purchased this product",
                StatusCodeEnum.BadRequest_400,
                null
            );
        }
        //create rating
        var newRating = new Rating
        {
            AccountID = createRating.AccountID,
            ProductID = createRating.ProductID,
            Rate = createRating.Rate,
            CreatedAt = DateTime.Now
        };
        var response = await _ratingRepository.AddAsync(newRating);
        var result = _mapper.Map<RatingResponse>(response);
        return new BaseResponse<RatingResponse>("Add rating successfully", StatusCodeEnum.OK_200, result);
    }

    public async Task<bool> DeleteRatingAsync(int ratingId)
    {
        var ratingExist = await _ratingRepository.GetByIdAsync(ratingId);
        await _ratingRepository.DeleteAsync(ratingExist);
        return true;
    }

    public async Task<BaseResponse<IEnumerable<RatingResponse>>> GetRatingByProductId(int productId)
    {
        var ratings = await _ratingRepository.GetRatingByProductId(productId);
        var result = _mapper.Map<IEnumerable<RatingResponse>>(ratings);
        return new BaseResponse<IEnumerable<RatingResponse>>("Get done", StatusCodeEnum.OK_200, result);
    }

    public async Task<BaseResponse<IEnumerable<RatingResponse>>> GetRatingByAccountId(string accountId)
    {
        var ratings = await _ratingRepository.GetRatingByAccountId(accountId);
        if(ratings == null)
        {
            return new BaseResponse<IEnumerable<RatingResponse>>("Get Fail", StatusCodeEnum.BadRequest_400, null);
        }
        var result = _mapper.Map<IEnumerable<RatingResponse>>(ratings);
        return new BaseResponse<IEnumerable<RatingResponse>>("Get done", StatusCodeEnum.OK_200, result);
    }

    public async Task<BaseResponse<RatingResponse>> UpdateRatingAsync(UpdateRatingRequest request)
    {
        var ratingExist = await _ratingRepository.GetByIdAsync(request.RatingID);
        _mapper.Map(request, ratingExist);
        await _ratingRepository.UpdateAsync(ratingExist);
        var result = _mapper.Map<RatingResponse>(ratingExist);
        return new BaseResponse<RatingResponse>("Update rate successfully", StatusCodeEnum.OK_200, result);
    }

    
}