using Kasa.Core.Domain;

namespace Kasa.Infrastructure.Services
{
    public interface IBankAccountService
    {
        Task<int> AddBankAccount(BankAccount bankAccount);
        Task UpdateBankAccount(BankAccount bankAccount);
        Task DeleteBankAccount(int bankAccountId);
        Task<BankAccount> GetBankAccountById(int bankAccountId);
        Task<IEnumerable<BankAccount>> GetBankAccountsBySourceId(int sourceId, AccountOwner accountOwner);
    }
}
