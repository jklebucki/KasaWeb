using Kasa.Core.Domain;

namespace Kasa.Core.Repositories
{
    public interface IBankAccountRepository
    {
        Task<int> Add(BankAccount bankAccount);
        Task Remove(int id);
        Task Update(BankAccount bankAccount);
        Task<BankAccount> GetById(int id);
        Task<IEnumerable<BankAccount>> GetBankAccounts(int sourceId, AccountOwnerType accountOwnerType);
    }
}
