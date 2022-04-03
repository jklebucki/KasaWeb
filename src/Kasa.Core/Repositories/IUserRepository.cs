using Kasa.Core.Domain;

namespace Kasa.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);
        Task<User> GetAsync(string email);
        Task<IEnumerable<User>> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetByCompanyGroupAsync(int companyGroupId);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
