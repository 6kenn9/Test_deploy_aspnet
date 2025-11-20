using System.Collections.Generic;
using System.Linq; // Треба для фільтрації (Where)
using System.Threading.Tasks;
using InstrumentRentalApi.Models;
using InstrumentRentalApi.Repositories;

namespace InstrumentRentalApi.Services
{
    public class InstrumentService : IInstrumentService
    {
        // Лишаємо твій загальний репозиторій
        private readonly IRepository<Instrument> _instrumentRepository;

        public InstrumentService(IRepository<Instrument> instrumentRepository)
        {
            _instrumentRepository = instrumentRepository;
        }

        public Task<Instrument> CreateAsync(Instrument instrument) => _instrumentRepository.CreateAsync(instrument);

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _instrumentRepository.GetByIdAsync(id);
            if (existing == null) return false;
            await _instrumentRepository.DeleteAsync(id);
            return true;
        }

        public Task<List<Instrument>> GetAllAsync() => _instrumentRepository.GetAllAsync();
        public Task<Instrument> GetByIdAsync(string id) => _instrumentRepository.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(string id, Instrument instrument)
        {
            var existing = await _instrumentRepository.GetByIdAsync(id);
            if (existing == null) return false;

            instrument.Id = id;
            await _instrumentRepository.UpdateAsync(id, instrument);
            return true;
        }

        // 👇 РЕАЛІЗАЦІЯ БЕЗ НОВИХ РЕПОЗИТОРІЇВ
        public async Task<List<Instrument>> GetAllByOwnerAsync(string? userId)
        {
            // 1. Беремо ВСІ інструменти
            var allInstruments = await _instrumentRepository.GetAllAsync();

            // 2. Фільтруємо їх тут вручну
            return allInstruments.Where(i => i.OwnerId == userId).ToList();
        }
    }
}