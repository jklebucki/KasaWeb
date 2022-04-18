using Kasa.Core.Domain;

namespace Kasa.Infrastructure.Services
{
    public interface IUserService
    {
        Task<int> CreateAsync(User user);
        Task<User> GetAsync(int userId);
        Task<IEnumerable<User>> GetCompanyGroupUsersAsync(int companyGroupId);
        Task Update(User user);
        Task Remove(int userId);
        Task ChangePassword(int userId, string oldPassword, string newPassword);
    }
}