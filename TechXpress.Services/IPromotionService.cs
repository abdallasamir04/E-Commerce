using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Models;

namespace TechXpress.Services
{
    public interface IPromotionService
    {
        Task<List<Promotion>> GetAllPromotionsAsync();
        Task<Promotion?> GetPromotionByIdAsync(int promotionId);
        Task<Promotion> CreatePromotionAsync(Promotion promotion);
        Task UpdatePromotionAsync(Promotion promotion);
        Task DeletePromotionAsync(int promotionId);
        // Add Methods to Get Promotions
        Task<List<Promotion>> GetActivePromotionsAsync();
        Task<List<Promotion>> GetFuturePromotionsAsync();
        Task<List<Promotion>> GetPastPromotionsAsync();
    }
}