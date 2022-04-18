using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Security;

namespace Kasa.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityProvider _securityProvider;
        public UserService(IUserRepository userRepository, ISecurityProvider securityProvider)
        {
            _userRepository = userRepository;
            _securityProvider = securityProvider;
        }

        public async Task ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
                throw new Exception($"User with ID {userId} does not exist");
            if (await _securityProvider.CompareOldPassword(oldPassword, user.Password))
            {
                var newPasswordHash = await _securityProvider.EncodePassword(newPassword).ConfigureAwait(false);
                await _userRepository.ChangePassword(userId, newPasswordHash);
            }
            else
                throw new Exception($"Old password incorrect");

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