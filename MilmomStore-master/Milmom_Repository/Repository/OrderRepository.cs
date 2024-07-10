using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using Milmom_Repository.BaseRepository;

namespace Milmom_Repository.Repository;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    private readonly OrderDAO _orderDao;
    public OrderRepository(OrderDAO orderDao) : base(orderDao)
    {
        _orderDao = orderDao;
    }

    public async Task AddOrderAsync(Order order)
    {
         await _orderDao.AddOrderAsync(order);
    }

    public async Task UpdateOrderAsync( Order order)
    {
       await _orderDao.UpdateAsync(order);
    }

    public async Task<IEnumerable<Order>> GetAllOrderAsync(DateTime? date, OrderStatus? status)
    {
        return await _orderDao.GetAllOrderAsync(date, status);
    }

    public async Task<bool> HasPurchasedProductAsync(string accountId, int productId)
    {
        return await _orderDao.HasPurchasedProductAsync(accountId, productId);
    }

    public async Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return await _orderDao.GetOrderByIdAsync(orderId);
    }

    public async Task<IEnumerable<Order>> GetOrdersByAccountId(string accountId)
    {
        return await _orderDao.GetOrdersByAccountId(accountId);
    }

    public async Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date)
    {
        return await _orderDao.GetOrdersByDateAsync(date);
    }

    public async Task<Order> ChangeOrderStatus(int orderId, OrderStatus status)
    {
        return await _orderDao.ChangeOrderStatus(orderId, status);
    }

    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        return await _orderDao.GetOrdersByStatusAsync(status);
    }

    //For admin dashboard
    public async Task<(double totalAmount, double totalProfit, int totalProducts)> GetTotalAmountTotalProductsOfWeek()
    {
        return await _orderDao.GetTotalAmountTotalProductsOfWeek();
    }

    public async Task<List<(string ProductName, int QuantitySold)>> GetTopProductsSoldInMonthAsync()
    {
        return await _orderDao.GetTopProductsSoldInMonthAsync();
    }

    public async Task<List<(string Month, double Revenue)>> GetStoreRevenueByMonthAsync()
    {
        return await _orderDao.GetStoreRevenueByMonthAsync();
    }

    public async Task<(int ordersReturnOrCancell, int orders, int ordersComplete, int ordersCancell, int ordersReturnRefund, int ordersReport)> GetStaticOrders()
    {
        return await _orderDao.GetStaticOrders();
    }

    public async Task<List<(object span, int totalOrders, double totalOrdersAmount)>> GetTotalOrdersTotalOrdersAmountAsync
        (DateTime startDate, DateTime endDate, string? timeSpanType)
    {
        return await _orderDao.GetTotalOrdersTotalOrdersAmountAsync(startDate, endDate, timeSpanType);
    }
}