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
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly TechXpressDbContext _dbContext;

        public ShoppingCartService(TechXpressDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ShoppingCart>> GetAllShoppingCartsAsync()
        {
            return await _dbContext.ShoppingCarts.ToListAsync();
        }

        public async Task<ShoppingCart?> GetShoppingCartByIdAsync(int cartId)
        {
            var shoppingCart = await _dbContext.ShoppingCarts.FindAsync(cartId);
            if (shoppingCart == null)
            {
                return null;
            }
            return shoppingCart;
        }

        public async Task<ShoppingCart> CreateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            _dbContext.ShoppingCarts.Add(shoppingCart);
            await _dbContext.SaveChangesAsync();
            return shoppingCart;
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            _dbContext.Entry(shoppingCart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteShoppingCartAsync(int cartId)
        {
            var shoppingCart = await _dbContext.ShoppingCarts.FindAsync(cartId);
            if (shoppingCart != null)
            {
                _dbContext.ShoppingCarts.Remove(shoppingCart);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<ShoppingCart>> GetShoppingCartsByUserIdAsync(int userId)
        {
            return await _dbContext.ShoppingCarts
                .Where(sc => sc.UserId == userId)
                .ToListAsync();
        }
    }
}