using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.Order;
using MilmomStore_BusinessObject.Model;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("get-all-orders-by-id/{accountId}")]
        public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByAccountIdAsync(string accountId)
        {
            return await _orderService.GetAllOrdersByAccountIdAsync(accountId);
        }

        [Authorize(Roles = "Staff, Customer")]
        [HttpGet("get-all-orders")]
        public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersAsync(DateTime? date, OrderStatus? status)
        {
            return await _orderService.GetAllOrderAsync(date, status);
        }

        [Authorize(Roles = "Staff, Customer")]
        [HttpPut("update-order-status")]
        public async Task<BaseResponse<OrderResponse>> ChangeOrderStatus(int orderId, OrderStatus status)
        {
            return await _orderService.ChangeOrderStatus(orderId, status);
        }

        [Authorize(Roles = "Staff, Customer")]
        [HttpGet("get-order-by-id/{orderId}")]
        public async Task<BaseResponse<OrderResponse>> GetOrderByIdAsync(int orderId)
        {
            return await _orderService.GetOrderByIdAsync(orderId);
        }

        //for admin Dashboard
        [Authorize(Roles = "Admin")]
        [HttpGet("adminDashBoard/GetTotalAmountTotalProductsOfWeek")]
        public async Task<BaseResponse<GetTotalAmountTotalProducts>> GetTotalAmountTotalProductsOfWeek()
        {
            return await _orderService.GetTotalAmountTotalProductsOfWeek();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("adminDashBoard/GetStaticOrders")]
        public async Task<BaseResponse<GetStaticOrders>> GetStaticOrders()
        {
            return await _orderService.GetStaticOrders();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("adminDashBoard/GetTopProductsSoldInMonth")]
        public async Task<BaseResponse<GetTopProductsSoldInMonth>> GetTopProductsSoldInMonthAsync()
        {
            return await _orderService.GetTopProductsSoldInMonthAsync();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("adminDashBoard/GetStoreRevenueByMonth")]
        public async Task<BaseResponse<GetStoreRevenueByMonth>> GetStoreRevenueByMonthAsync()
        {
            return await _orderService.GetStoreRevenueByMonthAsync();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("adminDashBoard/GetTotalOrdersTotalOrdersAmount")]
        public async Task<BaseResponse<List<GetTotalOrdersTotalOrdersAmount>>> GetTotalOrdersTotalOrdersAmountAsync
            (DateTime startDate, DateTime endDate, string? timeSpanType)
        {
            return await _orderService.GetTotalOrdersTotalOrdersAmountAsync(startDate,endDate,timeSpanType);
        }
    }
}