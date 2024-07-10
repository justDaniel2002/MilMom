using MilmomStore_BusinessObject.Model;
using Milmom_Repository.IBaseRepository;
namespace Milmom_Repository.IRepository;

public interface IOrderRepository:IBaseRepository<Order>
{
    public Task AddOrderAsync(Order order);
    public Task<bool> HasPurchasedProductAsync(string accountId, int productId);
    public Task<Order?> GetOrderByIdAsync(int orderId);
    public Task<IEnumerable<Order>> GetOrdersByAccountId(string accountId);
    public Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date);
    public Task<Order> ChangeOrderStatus(int orderId, OrderStatus status);
    public Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
    public Task UpdateOrderAsync( Order order);
    public Task<IEnumerable<Order>> GetAllOrderAsync(DateTime? date, OrderStatus? status);

    // For admin DashBoard
    public Task<(double totalAmount, double totalProfit, int totalProducts)> GetTotalAmountTotalProductsOfWeek();
    public Task<(int ordersReturnOrCancell, int orders, int ordersComplete, int ordersCancell, int ordersReturnRefund, int ordersReport)> GetStaticOrders();
    public Task<List<(string ProductName, int QuantitySold)>> GetTopProductsSoldInMonthAsync();
    public Task<List<(string Month, double Revenue)>> GetStoreRevenueByMonthAsync();
    Task<List<(object span, int totalOrders, double totalOrdersAmount)>> GetTotalOrdersTotalOrdersAmountAsync
        (DateTime startDate, DateTime endDate, string? timeSpanType);
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
}