using InstrumentRentalApi.Models;
using InstrumentRentalApi.Repositories;
namespace InstrumentRentalApi.Services 
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> CreateAsync(Category category) => _categoryRepository.CreateAsync(category);

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _categoryRepository.GetByIdAsync(id);
            if (existing == null) return false;
            await _categoryRepository.DeleteAsync(id);
            return true;
        }

        public Task<List<Category>> GetAllAsync() => _categoryRepository.GetAllAsync();
        public Task<Category> GetByIdAsync(string id) => _categoryRepository.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(string id, Category category)
        {
            var existing = await _categoryRepository.GetByIdAsync(id);
            if (existing == null) return false;
            category.Id = id;
            await _categoryRepository.UpdateAsync(id, category);
            return true;
        }
    }
}