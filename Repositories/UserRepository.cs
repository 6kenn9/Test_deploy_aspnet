using MongoDB.Driver;
using InstrumentRentalApi.Models; 
using System.Threading.Tasks;

namespace InstrumentRentalApi.Repositories 
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(IMongoDatabase database) : base(database)
        {
            _collection = database.GetCollection<User>("Users");
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}