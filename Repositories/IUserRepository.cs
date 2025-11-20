using InstrumentRentalApi.Models; 
using System.Threading.Tasks;

namespace InstrumentRentalApi.Repositories 
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<User?> GetByEmailAsync(string email);
    }
}