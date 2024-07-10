using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Order;
using Milmom_Service.Model.Response.Order;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task UpdateOrderStatus(int orderId, string status)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }
        order.Status = Enum.Parse<OrderStatus>(status);
        await _orderRepository.UpdateAsync(order);
    }

    public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByAccountIdAsync(string accountId)
    {
        var orders = await _orderRepository.GetOrdersByAccountId(accountId);
        var ordersResponse = _mapper.Map<IEnumerable<OrderResponse>>(orders);
        return new BaseResponse<IEnumerable<OrderResponse>>("Get ok", StatusCodeEnum.OK_200, ordersResponse);
    }

    public async Task<BaseResponse<OrderResponse>> ChangeOrderStatus(int orderId, OrderStatus status)
    {
        var order = await _orderRepository.ChangeOrderStatus(orderId, status);
        var orderResponse = _mapper.Map<OrderResponse>(order);
        return new BaseResponse<OrderResponse>("Change status ok", StatusCodeEnum.OK_200, orderResponse);
    }

    public async Task<BaseResponse<OrderResponse>> GetOrderByIdAsync(int orderId)
    {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return new BaseResponse<OrderResponse>("Get ok", StatusCodeEnum.OK_200, orderResponse);
    }

    public async Task<BaseResponse<OrderRequest>> UpdateOrderAsync(int orderId, OrderRequest request)
    {
        var orderExist = await _orderRepository.GetByIdAsync(orderId);
        if (orderExist == null)
        {
            throw new Exception("Order not found");
        }
        orderExist.ReportID = request.ReportID;
        var OrderUpdate = await _orderRepository.UpdateAsync(orderExist);
        var orderResponse = _mapper.Map<OrderRequest>(OrderUpdate);
        return new BaseResponse<OrderRequest>("Get ok", StatusCodeEnum.OK_200, orderResponse);
    }

    public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrderAsync(DateTime? date, OrderStatus? status)
    {
        var orders = await _orderRepository.GetAllOrderAsync(date, status);
        var ordersResponse = _mapper.Map<IEnumerable<OrderResponse>>(orders);
        return new BaseResponse<IEnumerable<OrderResponse>>("Get ok", StatusCodeEnum.OK_200, ordersResponse);
    }

    //For admindashboard
    public async Task<BaseResponse<GetTotalAmountTotalProducts>> GetTotalAmountTotalProductsOfWeek()
    {
        var total = await _orderRepository.GetTotalAmountTotalProductsOfWeek();
        /*var response = _mapper.Map<GetTotalAmountTotalProducts>(total);*/
        var response = new GetTotalAmountTotalProducts
        {
            totalAmount = total.totalAmount,
            totalProfit = total.totalProfit,
            totalProducts = total.totalProducts
        };
        if(response == null)
        {
            return new BaseResponse<GetTotalAmountTotalProducts>("Get All Fails", StatusCodeEnum.BadGateway_502, response);
        }
        return new BaseResponse<GetTotalAmountTotalProducts>("Get All Success", StatusCodeEnum.OK_200, response);
    }

    public async Task<BaseResponse<GetStaticOrders>> GetStaticOrders()
    {
        var order = await _orderRepository.GetStaticOrders();
        var response = new GetStaticOrders
        {
            orders = order.orders,
            ordersReturnOrCancell = order.ordersReturnOrCancell,
            ordersCancell = order.ordersCancell,
            ordersComplete = order.ordersComplete,
            ordersReport = order.ordersReport,
            ordersReturnRefund = order.ordersReturnRefund
        };
        if(response == null)
        {
            return new BaseResponse<GetStaticOrders>("Get All Fail", StatusCodeEnum.BadGateway_502, response);
        }
        return new BaseResponse<GetStaticOrders>("Get All Success", StatusCodeEnum.OK_200, response);
    }

    public async Task<BaseResponse<GetTopProductsSoldInMonth>> GetTopProductsSoldInMonthAsync()
    {
        var products = await _orderRepository.GetTopProductsSoldInMonthAsync();
        var response = new GetTopProductsSoldInMonth
        {
            topProducts = products.Select(o => (o.ProductName, o.QuantitySold)).ToList()
        };
        if(response == null)
        {
            return new BaseResponse<GetTopProductsSoldInMonth>("Get All Fail", StatusCodeEnum.BadGateway_502, response);
        }
        return new BaseResponse<GetTopProductsSoldInMonth>("Get All Success", StatusCodeEnum.OK_200, response);
    }

    public async Task<BaseResponse<GetStoreRevenueByMonth>> GetStoreRevenueByMonthAsync()
    {
        var total = await _orderRepository.GetStoreRevenueByMonthAsync();
        var response = new GetStoreRevenueByMonth
        {
            MonthList = total.Select(o => (o.Month,o.Revenue)).ToList()
        };
        if(response == null)
        {
            return new BaseResponse<GetStoreRevenueByMonth>("Get All Fail", StatusCodeEnum.BadGateway_502, response);
        }
        return new BaseResponse<GetStoreRevenueByMonth>("Get All Success", StatusCodeEnum.OK_200, response);
    }

    public async Task<BaseResponse<List<GetTotalOrdersTotalOrdersAmount>>> GetTotalOrdersTotalOrdersAmountAsync(DateTime startDate, DateTime endDate, string? timeSpanType)
    {
        var total = await _orderRepository.GetTotalOrdersTotalOrdersAmountAsync(startDate, endDate, timeSpanType);
        var response = total.Select(p => new GetTotalOrdersTotalOrdersAmount
        {
            span = p.span,
            totalOrders = p.totalOrders,
            totalOrdersAmount = p.totalOrdersAmount
        }).ToList();
        if (response == null)
        {
            return new BaseResponse<List<GetTotalOrdersTotalOrdersAmount>>("Get Top Product In A Month Fail", StatusCodeEnum.BadRequest_400, response);
        }
        return new BaseResponse<List<GetTotalOrdersTotalOrdersAmount>>("Get All Success", StatusCodeEnum.OK_200, response);
    }
}