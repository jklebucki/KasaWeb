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

        public async Task DeleteAsync(int userId)
        {
            var user = await _kasaDbContext.Users.FirstOrDefaultAsync(c => c.Id == userId);
            if (user != null)
            {
                _kasaDbContext.Users.Remove(user);
                await _kasaDbContext.SaveChangesAsync();
            }
            else
                throw new Exception($"There is no user with the given ID {userId}");
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _kasaDbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
                return user;
            else
                throw new Exception($"There is no user with the given ID {id}");
        }

        public async Task<User> GetAsync(string email)
        {
            var user = await _kasaDbContext.Users.FirstOrDefaultAsync(c => c.Email == email);
            if (user != null)
                return user;
            else
                throw new Exception($"There is no user with the given email {email}");
        }

        public async Task<IEnumerable<User>> GetByEmailAsync(string email)
        {
            return await _kasaDbContext.Users.Where(c => c.Email.Contains(email)).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByCompanyGroupAsync(int companyId)
        {
            return await _kasaDbContext.Users.Where(c => c.CompanyGroupId == companyId).ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var userToUpdate = await _kasaDbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Update(user.CompanyGroupId, user.Role, user.Name, user.FirstName, user.LastName, user.Email, user.Password);
                _kasaDbContext.Update(userToUpdate);
                await _kasaDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"User {user.Name} with the email address {user.Email} does not exist.");
            }
        }
    }
}