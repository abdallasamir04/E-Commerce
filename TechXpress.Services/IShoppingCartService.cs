using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Models;

namespace TechXpress.Services
{
    public interface IShoppingCartService
    {
        Task<List<ShoppingCart>> GetAllShoppingCartsAsync();
        Task<ShoppingCart?> GetShoppingCartByIdAsync(int cartId);
        Task<ShoppingCart> CreateShoppingCartAsync(ShoppingCart shoppingCart);
        Task UpdateShoppingCartAsync(ShoppingCart shoppingCart);
        Task DeleteShoppingCartAsync(int cartId);
        Task<List<ShoppingCart>> GetShoppingCartsByUserIdAsync(int userId);
    }
}