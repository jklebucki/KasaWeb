using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KasaDbContext _kasaDbContext;
        public UserRepository(KasaDbContext kasaDbContext)
        {
            _kasaDbContext = kasaDbContext;
        }
        public async Task AddAsync(User user)
        {
            _kasaDbContext.Users.Add(user);
            await _kasaDbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetByEmailAsync(string email)
        {
            return await _kasaDbContext.Users.Where(c => c.Email.Contains(email)).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByCompanyGroupAsync(int companyId)
        {
            return await _kasaDbContext.Users.Where(c => c.CompanyGroupId == companyId).ToListAsync();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}