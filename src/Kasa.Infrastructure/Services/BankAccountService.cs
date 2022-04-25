using Kasa.Core.Domain;
using Kasa.Core.Repositories;

namespace Kasa.Infrastructure.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<int> AddBankAccount(BankAccount bankAccount)
        {
            return await _bankAccountRepository.Add(bankAccount);
        }

        public async Task DeleteBankAccount(int bankAccountId)
        {
            await _bankAccountRepository.Remove(bankAccountId);
        }

        public async Task<BankAccount> GetBankAccountById(int bankAccountId)
        {
            return await _bankAccountRepository.GetById(bankAccountId);
        }

        public async Task<IEnumerable<BankAccount>> GetBankAccountsBySourceId(int sourceId, AccountOwner accountOwner)
        {
            return await _bankAccountRepository.GetBankAccounts(sourceId, accountOwner);
        }

        public async Task UpdateBankAccount(BankAccount bankAccount)
        {
            await _bankAccountRepository.Update(bankAccount);
        }
    }
}
