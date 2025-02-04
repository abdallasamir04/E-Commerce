using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data; // Make sure this is the correct namespace for your DbContext
using TechXpress.Data.Models; // Make sure this is the correct namespace for your models
using Microsoft.EntityFrameworkCore;

namespace TechXpress.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly TechXpressDbContext _dbContext;

        public CategoryService(TechXpressDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);
            if (category == null)
            {
                throw new CategoryNotFoundException($"Category with ID {categoryId} not found.");
            }
            return category;
        }
        public class CategoryNotFoundException : Exception
        {
            public CategoryNotFoundException(string message) : base(message) { }
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}