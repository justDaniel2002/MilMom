namespace Milmom_Service.Model.Request.VnPayModel;

public class VnPayRequestModel
{
    public int OrderId { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public string OrderInfor { get; set; }
}