using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentRentalApi.Models; 

namespace InstrumentRentalApi.Repositories
{
    public interface IRepository<T> where T : IBaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}