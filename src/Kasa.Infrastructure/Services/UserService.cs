using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Data;
using Kasa.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly KasaDbContext _kasaDbContext;
        public UserService(KasaDbContext kasaDbContext, IMapper mapper)
        {
            _kasaDbContext = kasaDbContext;
            _mapper = mapper;
        }
        public async Task CreateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _kasaDbContext.Users.Add(user);
            await _kasaDbContext.SaveChangesAsync();
        }

        public Task<UserDto> GetAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetCompanyUsersAsync(int companyId)
        {
            var companyUsers = await _kasaDbContext.Users.Where(x => x.CompanyId == companyId).ToListAsync();
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