using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Common;
using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KasaDbContext _kasaDbContext;
        public UserRepository(KasaDbContext kasaDbContext)
        {
            _kasaDbContext = kasaDbContext ?? throw new ArgumentNullException(nameof(kasaDbContext));
        }
        public async Task<int> AddAsync(User user)
        {
            await RepositoryCommon.CheckIfCompanyGroupExist(_kasaDbContext, user.CompanyGroupId);
            _kasaDbContext.Users.Add(user);
            await _kasaDbContext.SaveChangesAsync();
            return user.Id;
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
            => await _kasaDbContext.Users.Where(c => c.Email.Contains(email)).ToListAsync();

        public async Task<IEnumerable<User>> GetByCompanyGroupAsync(int companyId)
            => await _kasaDbContext.Users.Where(c => c.CompanyGroupId == companyId).ToListAsync();

        public async Task UpdateAsync(User user)
        {
            await RepositoryCommon.CheckIfCompanyGroupExist(_kasaDbContext, user.CompanyGroupId);
            var userToUpdate = await _kasaDbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Update(user.CompanyGroupId, user.Role, user.Name, user.FirstName, user.LastName, user.Email);
                _kasaDbContext.Update(userToUpdate);
                await _kasaDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"User {user.Name} with the email address {user.Email} does not exist.");
            }
        }

        public async Task ChangePassword(int userId, string newPasswordHash)
        {
            var userToUpdate = await _kasaDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (userToUpdate != null)
            {
                userToUpdate.SetPassword(newPasswordHash);
                _kasaDbContext.Update(userToUpdate);
                await _kasaDbContext.SaveChangesAsync();
            }
            else
                throw new Exception($"There is no user with the given ID {userId}");
        }
    }
}