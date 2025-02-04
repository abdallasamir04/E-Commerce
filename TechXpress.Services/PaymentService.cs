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
    public class PaymentService : IPaymentService
    {
        private readonly TechXpressDbContext _dbContext;

        public PaymentService(TechXpressDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _dbContext.Payments.ToListAsync();
        }

        public async Task<Payment?> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _dbContext.Payments.FindAsync(paymentId);
            if (payment == null)
            {
                return null;
            }
            return payment;
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _dbContext.Entry(payment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int paymentId)
        {
            var payment = await _dbContext.Payments.FindAsync(paymentId);
            if (payment != null)
            {
                _dbContext.Payments.Remove(payment);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Payment>> GetPaymentsByOrderIdAsync(int orderId)
        {
            return await _dbContext.Payments
                .Where(p => p.OrderId == orderId)
                .ToListAsync();
        }
        public async Task<bool> UpdatePaymentStatusAsync(int paymentId, string newStatus)
        {
            var payment = await _dbContext.Payments.FindAsync(paymentId);
            if (payment == null)
            {
                return false; // Payment not found
            }

            payment.PaymentStatus = newStatus;
            _dbContext.Entry(payment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true; // Status updated successfully
        }
    }
}