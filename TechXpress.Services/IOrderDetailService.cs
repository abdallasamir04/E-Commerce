using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Models;

namespace TechXpress.Services
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAllOrderDetailsAsync();
        Task<OrderDetail?> GetOrderDetailByIdAsync(int orderDetailId);
        Task<OrderDetail> CreateOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailAsync(int orderDetailId);
        Task<List<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId);
    }
}