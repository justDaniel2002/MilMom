using Milmom_Service.Model.Request.ShippingRequest;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.IService;

public interface ICheckoutService
{
    public Task<Order> Checkout(string accountId, ShippingRequest shippingRequest, PaymentMethod paymentMethod);
    public Task<bool> ValidateCart(string accountId);
    public Task<Order> CreateOrder(int orderId, Transaction transaction);
    public Task<double> GetAmount(string accountId);

    public double CalculateShippingFee(string provinceCode);
}