using Kasa.Core.Domain;

namespace Kasa.Core.Repositories
{
    public interface ILocationBankAccountsRepository
    {
        Task<int> Add(LocationBankAccount locationBankAccount);
        Task Remove(int id);
        Task Update(LocationBankAccount locationBankAccount);
        Task<LocationBankAccount> GetById(int id);
        Task<IEnumerable<LocationBankAccount>> GetLocationBankAccounts(int locationId);
    }
}
