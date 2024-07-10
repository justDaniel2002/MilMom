namespace Milmom_Service.Model.Request.Rating;

public class CreateRatingRequest
{
    public string AccountID { get; set; }
    public int Rate   { get; set; }
    public int ProductID { get; set; }
}