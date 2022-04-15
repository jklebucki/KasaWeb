using Kasa.Core.Domain;
using Kasa.Core.Repositories;
namespace Kasa.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> CreateAsync(User user)
        {
            var newUser = new User(0, user.CompanyGroupId, user.Role, user.Name, user.FirstName, user.LastName, user.Email, user.Password);
            return await _userRepository.AddAsync(newUser);
        }

        public async Task<User> GetAsync(int userId)
        {
            return await _userRepository.GetAsync(userId);
        }

        public async Task<IEnumerable<User>> GetCompanyGroupUsersAsync(int companyGroupId)
        {
            return await _userRepository.GetByCompanyGroupAsync(companyGroupId);
        }

        public async Task Remove(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task Update(User user)
        {
            await _userRepository.UpdateAsync(user);
        }
    }
}