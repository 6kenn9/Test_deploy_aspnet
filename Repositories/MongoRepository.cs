using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentRentalApi.Models; 

namespace InstrumentRentalApi.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : IBaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDatabase database)
        {
            var collectionName = typeof(T).Name + "s";
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(x => x.Id == id);
        public async Task<List<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<T> GetByIdAsync(string id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task UpdateAsync(string id, T entity) => await _collection.ReplaceOneAsync(x => x.Id == id, entity);
    }
} 