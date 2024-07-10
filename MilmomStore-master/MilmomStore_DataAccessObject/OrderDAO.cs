using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;

namespace MilmomStore_DataAccessObject;

public class OrderDAO : BaseDAO<Order>
{
    private readonly MilmomSystemContext _context;
    public OrderDAO(MilmomSystemContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllOrderAsync(DateTime? date = null, OrderStatus? status = null)
    {
        IQueryable<Order> orders = _context.Orders
            .Include(o => o.AccountApplication)
            .Include(o => o.ShippingInfor)
            .Include(o => o.Transaction)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .ThenInclude(p => p.ImageProducts);

        // Apply date filter if provided
        if (date.HasValue)
        {
            orders = orders.Where(o => o.OrderDate.Date == date.Value.Date);
        }

        // Apply status filter if provided
        if (status.HasValue)
        {
            orders = orders.Where(o => o.Status == status.Value);
        }

        // Execute the query and return the results as a list
        return await orders.ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByAccountId(string accountId)
    {
        return await _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .ThenInclude(o=>o.ImageProducts)
            .Include(o => o.ShippingInfor)
            .Include(o => o.Transaction)
            .Where(o => o.AccountID == accountId)
            .ToListAsync();
    }
    public async Task<Order?> ChangeOrderStatus(int orderId, OrderStatus status)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            order.Status = status;
            await _context.SaveChangesAsync();
        }

        return await _context.Orders.FindAsync(orderId);
    }
    public async Task AddOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> HasPurchasedProductAsync(string accountId, int productId)
    {
        return await _context.OrderDetails
            .AnyAsync(od => od.Order.AccountID == accountId && od.ProductID == productId);
    }
    public async Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date)
    {
        return await _context.Orders
            .Include(o => o.AccountApplication)
            .Include(o => o.ShippingInfor)
            .Include(o => o.Transaction)
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .ThenInclude(o=>o.ImageProducts)
            .Where(o => o.OrderDate.Date == date.Date)
            .ToListAsync();
    }
    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        return await _context.Orders
            .Include(o => o.AccountApplication)
            .Include(o => o.OrderDetails)
            .Where(o => o.Status == status)
            .ToListAsync();
    }
    public async Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .ThenInclude(o=>o.ImageProducts)
            .Include(o => o.ShippingInfor)
            .Include(o => o.Transaction)
            
            .FirstOrDefaultAsync(o => o.OrderID == orderId);
    }

    public async Task<Order?> UpdateOrderAsync(int orderId, Order order)
    {

        var existOrder = await _context.Orders.FindAsync(orderId);
        if (existOrder != null)
        {
            existOrder.ReportID = order.ReportID;
        }
        await _context.SaveChangesAsync();
        return existOrder;
    }

    public async Task<(double totalAmount, double totalProfit, int totalProducts)> GetTotalAmountTotalProductsOfWeek()
    {
        // Lấy ngày hiện tại
        DateTime today = DateTime.Today;

        // Xác định ngày đầu tuần (ngày thứ Hai là ngày đầu tuần)
        DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);

        // Xác định ngày cuối tuần (ngày Chủ nhật là ngày cuối tuần)
        DateTime endOfWeek = startOfWeek.AddDays(6);

        var order = _context.Orders
                            .Where(o => o.OrderDate >= startOfWeek
                                   && o.OrderDate <= endOfWeek
                                   && o.Status == OrderStatus.Completed);

        double totalAmount = await order
                            .SumAsync(o => o.Total);

        double totalCost = await _context.Orders
                                .SelectMany(o => o.OrderDetails)
                                .SumAsync(oi => oi.Product.UnitPrice * oi.Quantity);
        
        double profit = totalAmount - totalCost;

        double totalProfit = (profit / totalAmount) * 100;

        int totalProducts = await order
                            .SelectMany(o => o.OrderDetails)
                            .SumAsync(oi => oi.Quantity);

        return (totalAmount, totalProfit,totalProducts);
    }

    

    public async Task<(int ordersReturnOrCancell, int orders, int ordersComplete, int ordersCancell,int ordersReturnRefund, int ordersReport)> GetStaticOrders()
    {
        // Lấy ngày hiện tại
        DateTime today = DateTime.Today;

        // Xác định ngày đầu tuần (ngày thứ Hai là ngày đầu tuần)
        DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);

        // Xác định ngày cuối tuần (ngày Chủ nhật là ngày cuối tuần)
        DateTime endOfWeek = startOfWeek.AddDays(6);

        int ordersReturnOrCancell = await _context.Orders
                            .Where(o => o.OrderDate >= startOfWeek
                                   && o.OrderDate <= endOfWeek
                                   && (o.Status == OrderStatus.Cancelled
                                   || o.Status == OrderStatus.RequestReturn
                                   || o.Status == OrderStatus.ReturnRefund))
                            .CountAsync();

        int orders = await _context.Orders
                            .Where(o => o.OrderDate >= startOfWeek
                                   && o.OrderDate <= endOfWeek)
                            .CountAsync();

        int ordersComplete = await _context.Orders
                            .Where(o => o.OrderDate >= startOfWeek
                                   && o.OrderDate <= endOfWeek
                                   && o.Status == OrderStatus.Completed)
                            .CountAsync();

        int ordersCancell = await _context.Orders
                            .Where(o => o.OrderDate >= startOfWeek
                                   && o.OrderDate <= endOfWeek
                                   && o.Status == OrderStatus.Cancelled)
                            .CountAsync();

        int ordersReturnRefund = await _context.Orders
                            .Where(o => o.OrderDate >= startOfWeek
                                   && o.OrderDate <= endOfWeek
                                   && o.Status == OrderStatus.ReturnRefund)
                            .CountAsync();

        int ordersReport = await _context.Orders
                            .Where(o => o.OrderDate >= startOfWeek
                                   && o.OrderDate <= endOfWeek
                                   && o.ReportID != null)
                            .CountAsync();
        return (ordersReturnOrCancell,orders,ordersComplete,ordersCancell,ordersReturnRefund,ordersReport);
    }
    

    public async Task<List<(string ProductName, int QuantitySold)>> GetTopProductsSoldInMonthAsync()
    {
        // Lấy ngày hiện tại
        DateTime today = DateTime.Today;

        // Xác định ngày đầu tháng và ngày cuối tháng
        DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
        DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        // Lấy danh sách các Order trong khoảng thời gian từ startOfMonth đến endOfMonth
        IEnumerable<Order> ordersInMonth = await _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .Where(o => o.OrderDate.Date >= startOfMonth.Date && o.OrderDate.Date <= endOfMonth.Date)
            .ToListAsync();

        // Tính tổng số lượng sản phẩm đã bán của từng sản phẩm
        var productQuantities = ordersInMonth
            .SelectMany(o => o.OrderDetails)
            .GroupBy(od => od.Product.Name)
            .Select(g => new
            {
                ProductName = g.Key,
                QuantitySold = g.Sum(od => od.Quantity)
            })
            .OrderByDescending(x => x.QuantitySold)
            .Take(4)
            .ToList();

        // Chuyển đổi kết quả sang List<(string ProductName, int QuantitySold)>
        List<(string ProductName, int QuantitySold)> topProducts = productQuantities
            .Select(p => (p.ProductName, p.QuantitySold))
            .ToList();

        return topProducts;
    }

    public async Task<List<(string Month, double Revenue)>> GetStoreRevenueByMonthAsync()
    {
        // Get the current date
        DateTime today = DateTime.Today;

        // Initialize a list to store the revenue results
        List<(string Month, double Revenue)> revenueByMonth = new List<(string Month, double Revenue)>();

        // Loop through each month of the current year
        for (int month = 1; month <= 12; month++)
        {
            // Calculate the start and end dates of the current month
            DateTime startDateOfMonth = new DateTime(today.Year, month, 1);
            DateTime endDateOfMonth = startDateOfMonth.AddMonths(1).AddDays(-1);

            // Query to get orders within the current month
            double totalRevenueOfMonth = await _context.Orders
                .Where(o => o.OrderDate.Date >= startDateOfMonth &&
                       o.OrderDate.Date <= endDateOfMonth &&
                       o.Status == OrderStatus.Completed)
                .SumAsync(o => o.Total);

            // Format the month name (you can customize this part based on your needs)
            string monthName = startDateOfMonth.ToString("MMMM");

            // Add the result to the list
            revenueByMonth.Add((monthName, totalRevenueOfMonth));
        }

        return revenueByMonth;
    }

    // total order, total amount of day, week, month:
    public async Task<List<(object span, int totalOrders, double totalOrdersAmount)>> GetTotalOrdersTotalOrdersAmountAsync
        (DateTime startDate, DateTime endDate, string? timeSpanType)
    {
        List<(object span, int totalOrders, double totalOrdersAmount)> result = new List<(object, int, double)>();

        switch (timeSpanType?.ToLower())
        {
            case "day":
                // Show results for each day in the specified range
                for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
                {
                    DateTime currentDayStart = date.Date;
                    DateTime currentDayEnd = date.Date.AddDays(1).AddTicks(-1);

                    int totalOrders = await _context.Orders
                        .Where(o => o.OrderDate >= currentDayStart &&
                               o.OrderDate <= currentDayEnd &&
                               o.Status == OrderStatus.Completed)
                        .CountAsync();

                    double totalOrdersAmount = await _context.Orders
                        .Where(o => o.OrderDate >= currentDayStart &&
                               o.OrderDate <= currentDayEnd &&
                               o.Status == OrderStatus.Completed)
                        .SumAsync(o => o.Total);

                    result.Add((date.Date, totalOrders, totalOrdersAmount));
                }
                break;
            case "week":
                // Show results for each week in the specified range
                DateTime currentWeekStart = startDate.Date.AddDays(-(int)startDate.DayOfWeek + (int)DayOfWeek.Monday);
                if (currentWeekStart > startDate.Date)
                {
                    currentWeekStart = startDate.Date.AddDays(-(int)startDate.DayOfWeek - 6);
                }
                while (currentWeekStart <= endDate.Date)
                {
                    DateTime currentWeekEnd = currentWeekStart.AddDays(6);

                    if (currentWeekEnd > endDate.Date)
                    {
                        currentWeekEnd = endDate.Date.AddDays(-(int)endDate.DayOfWeek + 7); 
                    }

                    int totalOrders = await _context.Orders
                        .Where(o => o.OrderDate.Date >= currentWeekStart.Date &&
                                    o.OrderDate.Date <= currentWeekEnd.Date &&
                                    o.Status == OrderStatus.Completed)
                        .CountAsync();

                    double totalOrdersAmount = await _context.Orders
                        .Where(o => o.OrderDate.Date >= currentWeekStart.Date &&
                                    o.OrderDate.Date <= currentWeekEnd.Date &&
                                    o.Status == OrderStatus.Completed)
                        .SumAsync(o => o.Total);

                    // Format the week string as "MM/dd/yyyy - MM/dd/yyyy"
                    string weekRange = $"{currentWeekStart.ToString("MM/dd/yyyy")} - {currentWeekEnd.ToString("MM/dd/yyyy")}";

                    result.Add((weekRange, totalOrders, totalOrdersAmount));

                    // Move to the start of the next week
                    currentWeekStart = currentWeekEnd.AddDays(1);
                }
                break;
            case "month":
                // Show results for each month in the specified range
                DateTime currentMonthStart = new DateTime(startDate.Year, startDate.Month, 1);

                while (currentMonthStart <= endDate.Date)
                {
                    DateTime currentMonthEnd = currentMonthStart.AddMonths(1).AddDays(-1);

                    int totalOrders = await _context.Orders
                        .Where(o => o.OrderDate >= currentMonthStart &&
                                    o.OrderDate <= currentMonthEnd &&
                                    o.Status == OrderStatus.Completed)
                        .CountAsync();

                    double totalOrdersAmount = await _context.Orders
                        .Where(o => o.OrderDate >= currentMonthStart &&
                                    o.OrderDate <= currentMonthEnd &&
                                    o.Status == OrderStatus.Completed)
                        .SumAsync(o => o.Total);

                    // Format the month string as "MM/yyyy"
                    string monthName = currentMonthStart.ToString("MM/yyyy");

                    result.Add((monthName, totalOrders, totalOrdersAmount));

                    // Move to the start of the next month
                    currentMonthStart = currentMonthStart.AddMonths(1);
                }
                break;
            default:
                // Default to "ngày" if timeSpanType is unrecognized
                for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
                {
                    DateTime currentDayStart = date.Date;
                    DateTime currentDayEnd = date.Date.AddDays(1).AddTicks(-1);

                    int totalOrders = await _context.Orders
                        .Where(o => o.OrderDate >= currentDayStart &&
                                    o.OrderDate <= currentDayEnd &&
                                    o.Status == OrderStatus.Completed)
                        .CountAsync();

                    double totalOrdersAmount = await _context.Orders
                        .Where(o => o.OrderDate >= currentDayStart &&
                                    o.OrderDate <= currentDayEnd &&
                                    o.Status == OrderStatus.Completed)
                        .SumAsync(o => o.Total);

                    result.Add((date.Date, totalOrders, totalOrdersAmount));
                }
                break;
        }

        return result;
    }
}