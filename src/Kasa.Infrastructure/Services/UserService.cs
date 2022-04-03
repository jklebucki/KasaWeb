using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Data;
using Kasa.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly KasaDbContext _kasaDbContext;
        private readonly IUserRepository _userRepository;
        public UserService(KasaDbContext kasaDbContext, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _kasaDbContext = kasaDbContext;
            _mapper = mapper;
        }
        public async Task CreateAsync(UserDto userDto)
        {
            var user = new User(0,userDto.CompanyGroupId, userDto.Role, userDto.Name, userDto.FirstName, userDto.LastName, userDto.Email, "");
            await _userRepository.AddAsync(user);
        }

        public Task<UserDto> GetAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetCompanyUsersAsync(int companyId)
        {
            var companyUsers = await _kasaDbContext.Users.Where(x => x.CompanyGroupId == companyId).ToListAsync();
            return _mapper.Map<List<UserDto>>(companyUsers);
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