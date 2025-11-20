using InstrumentRentalApi.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstrumentRentalApi.Services 
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task<User> CreateAsync(User user);
        Task<bool> UpdateAsync(string id, User user);
        Task<bool> DeleteAsync(string id);
        Task<User?> GetByEmailAsync(string email);
    }
}