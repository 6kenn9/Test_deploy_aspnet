using InstrumentRentalApi.Models;
using InstrumentRentalApi.Repositories; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstrumentRentalApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _userRepository.GetByEmailAsync(email);
        }

        public Task<User> CreateAsync(User user) =>
            _userRepository.CreateAsync(user);

        public Task<List<User>> GetAllAsync() =>
            _userRepository.GetAllAsync();

        public Task<User> GetByIdAsync(string id) =>
            _userRepository.GetByIdAsync(id);

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null) return false;

            await _userRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> UpdateAsync(string id, User user)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null) return false;

            user.Id = id;

            user.PasswordHash = existing.PasswordHash;

            await _userRepository.UpdateAsync(id, user);
            return true;
        }
    }
}