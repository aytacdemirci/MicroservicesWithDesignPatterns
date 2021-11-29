using OrderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Business
{
    public interface IOrderBusiness
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<bool> CreateOrderAsync(CreateOrderRequestModel request);
        Task CancelOrderAsync(int orderId);

    }
}
