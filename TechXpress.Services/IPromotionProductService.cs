using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Models;

namespace TechXpress.Services
{
    public interface IPromotionProductService
    {
        Task<List<PromotionProduct>> GetAllPromotionProductsAsync();
        Task<PromotionProduct?> GetPromotionProductByIdAsync(int promotionProductId);
        Task<PromotionProduct> CreatePromotionProductAsync(PromotionProduct promotionProduct);
        Task UpdatePromotionProductAsync(PromotionProduct promotionProduct);
        Task DeletePromotionProductAsync(int promotionProductId);
        Task<List<PromotionProduct>> GetPromotionProductsByPromotionIdAsync(int promotionId);
        Task<List<PromotionProduct>> GetPromotionProductsByProductIdAsync(int productId);
    }
}