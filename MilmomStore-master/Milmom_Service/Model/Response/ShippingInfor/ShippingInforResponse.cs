namespace Milmom_Service.Model.Response.ShippingInfor;

public class ShippingInforResponse
{
    public string DetailAddress { get; set; }
    public string Province { get; set; }
    public string Ward { get; set; }
    public string District { get; set; }
    public string ReceiverName { get; set; }
    public string Phone { get; set; }
    public double ShippingCost { get; set; }
}