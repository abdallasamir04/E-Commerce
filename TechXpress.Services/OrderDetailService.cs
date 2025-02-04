using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data;
using TechXpress.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TechXpress.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly TechXpressDbContext _dbContext;

        public OrderDetailService(TechXpressDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _dbContext.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail?> GetOrderDetailByIdAsync(int orderDetailId)
        {
            var orderDetail = await _dbContext.OrderDetails.FindAsync(orderDetailId);
            if (orderDetail == null)
            {
                return null;
            }
            return orderDetail;
        }

        public async Task<OrderDetail> CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Add(orderDetail);
            await _dbContext.SaveChangesAsync();
            return orderDetail;
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            _dbContext.Entry(orderDetail).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderDetailAsync(int orderDetailId)
        {
            var orderDetail = await _dbContext.OrderDetails.FindAsync(orderDetailId);
            if (orderDetail != null)
            {
                _dbContext.OrderDetails.Remove(orderDetail);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _dbContext.OrderDetails
                .Where(od => od.OrderId == orderId)
                .ToListAsync();
        }
    }
}