using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Common;
using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly KasaDbContext _kasaDbContext;

        public BankAccountRepository(KasaDbContext kasaDbContext)
        {
            _kasaDbContext = kasaDbContext ?? throw new ArgumentNullException(nameof(kasaDbContext));
        }

        public async Task<int> Add(BankAccount bankAccount)
        {
            switch (bankAccount.AccountOwner)
            {
                case AccountOwnerType.Location:
                    await RepositoryCommon.CheckIfLocationExist(_kasaDbContext, bankAccount.SourceId);
                    break;
                case AccountOwnerType.Contractor:
                    await RepositoryCommon.CheckIfContractorExist(_kasaDbContext, bankAccount.SourceId);
                    break;
                default:
                    throw new Exception("Account owner must be defined.");
            }
            _kasaDbContext.Add(bankAccount);
            await _kasaDbContext.SaveChangesAsync();
            return bankAccount.Id;
        }

        public async Task<BankAccount> GetById(int id)
        {
            var bankAccount = await _kasaDbContext.BankAccounts.FirstOrDefaultAsync(c => c.Id == id);
            if (bankAccount == null)
                throw new Exception($"Bank account with ID: {id} does not exist.");
            return bankAccount;
        }

        public async Task<IEnumerable<BankAccount>> GetBankAccounts(int sourceId, AccountOwnerType accountOwnerType)
            => await _kasaDbContext.BankAccounts.Where(c => c.SourceId == sourceId && c.AccountOwner == accountOwnerType).ToListAsync();

        public async Task Remove(int id)
        {
            var bankAccount = await _kasaDbContext.BankAccounts.FirstOrDefaultAsync(c => c.Id == id);
            if (bankAccount == null)
                throw new Exception($"Bank account with ID: {id} does not exist.");
            try
            {
                _kasaDbContext.Remove(bankAccount);
                await _kasaDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
            }
        }

        public async Task Update(BankAccount bankAccount)
        {
            await RepositoryCommon.CheckIfLocationExist(_kasaDbContext, bankAccount.SourceId);
            var bankAccountToUpdate = await _kasaDbContext.BankAccounts.FirstOrDefaultAsync(c => c.Id == bankAccount.SourceId);
            if (bankAccountToUpdate == null)
                throw new Exception($"Company with ID: {bankAccount.Id} does not exist.");
            try
            {
                bankAccountToUpdate.Update(bankAccount.Id,
                                                   bankAccount.AccountOwner,
                                                   bankAccount.BankName,
                                                   bankAccount.BankAccountNumber);
                _kasaDbContext.Update(bankAccountToUpdate);
                await _kasaDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
            }
        }
    }
}
