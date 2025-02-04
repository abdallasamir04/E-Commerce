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
    public class PromotionService : IPromotionService
    {
        private readonly TechXpressDbContext _dbContext;

        public PromotionService(TechXpressDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Promotion>> GetAllPromotionsAsync()
        {
            return await _dbContext.Promotions.ToListAsync();
        }

        public async Task<Promotion?> GetPromotionByIdAsync(int promotionId)
        {
            var promotion = await _dbContext.Promotions.FindAsync(promotionId);
            if (promotion == null)
            {
                return null;
            }
            return promotion;
        }

        public async Task<Promotion> CreatePromotionAsync(Promotion promotion)
        {
            _dbContext.Promotions.Add(promotion);
            await _dbContext.SaveChangesAsync();
            return promotion;
        }

        public async Task UpdatePromotionAsync(Promotion promotion)
        {
            _dbContext.Entry(promotion).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePromotionAsync(int promotionId)
        {
            var promotion = await _dbContext.Promotions.FindAsync(promotionId);
            if (promotion != null)
            {
                _dbContext.Promotions.Remove(promotion);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Promotion>> GetActivePromotionsAsync()
        {
            DateTime currentDate = DateTime.Now;
            return await _dbContext.Promotions
                .Where(p => p.IsActive == true && p.StartDate <= currentDate && p.EndDate >= currentDate)
                .ToListAsync();
        }

        public async Task<List<Promotion>> GetFuturePromotionsAsync()
        {
            DateTime currentDate = DateTime.Now;
            return await _dbContext.Promotions
                .Where(p => p.StartDate > currentDate)
                .ToListAsync();
        }

        public async Task<List<Promotion>> GetPastPromotionsAsync()
        {
            DateTime currentDate = DateTime.Now;
            return await _dbContext.Promotions
                .Where(p => p.EndDate < currentDate)
                .ToListAsync();
        }
    }
}