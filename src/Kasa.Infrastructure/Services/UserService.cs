using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.DTO;
namespace Kasa.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(User user)
        {
            var newUser = new User(0, user.CompanyGroupId, user.Role, user.Name, user.FirstName, user.LastName, user.Email, user.Password);
            await _userRepository.AddAsync(newUser);
        }

        public Task<UserDto> GetAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetCompanyGroupUsersAsync(int companyGroupId)
        {
            var companyGroupUsers = await _userRepository.GetByCompanyGroupAsync(companyGroupId);
            return _mapper.Map<List<UserDto>>(companyGroupUsers);
        }

        public Task Remove(int userId)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}