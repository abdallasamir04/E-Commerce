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
    public class PromotionProductService : IPromotionProductService
    {
        private readonly TechXpressDbContext _dbContext;

        public PromotionProductService(TechXpressDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PromotionProduct>> GetAllPromotionProductsAsync()
        {
            return await _dbContext.PromotionProducts.ToListAsync();
        }

        public async Task<PromotionProduct?> GetPromotionProductByIdAsync(int promotionProductId)
        {
            var promotionProduct = await _dbContext.PromotionProducts.FindAsync(promotionProductId);
            if (promotionProduct == null)
            {
                return null;
            }
            return promotionProduct;
        }

        public async Task<PromotionProduct> CreatePromotionProductAsync(PromotionProduct promotionProduct)
        {
            _dbContext.PromotionProducts.Add(promotionProduct);
            await _dbContext.SaveChangesAsync();
            return promotionProduct;
        }

        public async Task UpdatePromotionProductAsync(PromotionProduct promotionProduct)
        {
            _dbContext.Entry(promotionProduct).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePromotionProductAsync(int promotionProductId)
        {
            var promotionProduct = await _dbContext.PromotionProducts.FindAsync(promotionProductId);
            if (promotionProduct != null)
            {
                _dbContext.PromotionProducts.Remove(promotionProduct);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<PromotionProduct>> GetPromotionProductsByPromotionIdAsync(int promotionId)
        {
            return await _dbContext.PromotionProducts
                .Where(pp => pp.PromotionId == promotionId)
                .ToListAsync();
        }

        public async Task<List<PromotionProduct>> GetPromotionProductsByProductIdAsync(int productId)
        {
            return await _dbContext.PromotionProducts
                .Where(pp => pp.ProductId == productId)
                .ToListAsync();
        }
    }
}