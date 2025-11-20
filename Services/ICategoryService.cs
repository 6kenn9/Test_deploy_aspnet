using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentRentalApi.Models;
namespace InstrumentRentalApi.Services 
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(string id);
        Task<Category> CreateAsync(Category category);
        Task<bool> UpdateAsync(string id, Category category);
        Task<bool> DeleteAsync(string id);
    }
}