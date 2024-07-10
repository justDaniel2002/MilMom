using Microsoft.AspNetCore.Http;

namespace Milmom_Service.Model.Request.Rating;

public class UpdateRatingRequest
{
    public int RatingID { get; set; }
    public string AccountID { get; set; }
    public int Rate   { get; set; }
    public int ProductID { get; set; }

    
}