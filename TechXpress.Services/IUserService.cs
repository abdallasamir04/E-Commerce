using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Models;

namespace TechXpress.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int userId);
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        //Additional methods example for authentication
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> ValidateUserPasswordAsync(string email, string password);
    }
}