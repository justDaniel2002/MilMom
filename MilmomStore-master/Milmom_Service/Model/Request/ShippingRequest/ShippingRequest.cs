namespace Milmom_Service.Model.Request.ShippingRequest;

public class ShippingRequest
{
    public string DetailAddress { get; set; }
    public string Province { get; set; }
    
    public string ProvinceCode { get; set; }
    
    public string Ward { get; set; }
    public string District { get; set; }
    public string ReceiverName { get; set; }
    public string Phone { get; set; }
    
    
}