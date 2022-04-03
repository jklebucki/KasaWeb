using Kasa.Core.Domain;
using Kasa.Infrastructure.DTO;

namespace Kasa.Infrastructure.Services
{
    public interface IUserService
    {
        Task CreateAsync(User user);
        Task<UserDto> GetAsync(int userId);
        Task<IEnumerable<UserDto>> GetCompanyGroupUsersAsync(int companyGroupId);
        Task Update(User user);
        Task Remove(int userId);
    }
}