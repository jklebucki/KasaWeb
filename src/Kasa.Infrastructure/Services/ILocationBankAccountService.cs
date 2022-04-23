using Kasa.Core.Domain;

namespace Kasa.Infrastructure.Services
{
    internal interface ILocationBankAccountService
    {
        Task<int> AddLocationBankAccount(LocationBankAccount locationBankAccount);
        Task UpdateLocationBankAccount(LocationBankAccount locationBankAccount);
        Task DeleteLocationBankAccount(int locationBankAccountId);
        Task<LocationBankAccount> GetLocationBankAccountById(int locationBankAccountId);
        Task<IEnumerable<LocationBankAccount>> GetLocationBankAccountsByLocationId(int locationId);
    }
}
