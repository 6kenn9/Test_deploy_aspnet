using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentRentalApi.Models;

namespace InstrumentRentalApi.Services
{
    public interface IInstrumentService
    {
        Task<List<Instrument>> GetAllAsync();
        Task<Instrument> GetByIdAsync(string id);
        Task<Instrument> CreateAsync(Instrument instrument);
        Task<bool> UpdateAsync(string id, Instrument instrument);
        Task<bool> DeleteAsync(string id);

        Task<List<Instrument>> GetAllByOwnerAsync(string? userId);
    }
}