using Kasa.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
