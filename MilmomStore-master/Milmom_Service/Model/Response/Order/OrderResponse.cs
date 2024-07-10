using Milmom_Service.Model.Response.Checkout;
using Milmom_Service.Model.Response.ShippingInfor;
using Milmom_Service.Model.Response.Transaction;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Model.Response.Order;

public class OrderResponse
{
    public int OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public double Total { get; set; }
    public int ReportID { get; set; }
    //
    public ICollection<OrderDetailResponse> OrderDetails { get; set; }
    public TransactionResponse? Transaction { get; set; }
    public ShippingInforResponse ShippingInfor { get; set; } = null!;
}