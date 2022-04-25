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
            _kasaDbContext = kasaDbContext;
        }

        public async Task<int> Add(BankAccount bankAccount)
        {
            switch (bankAccount.AccountOwner)
            {
                case AccountOwner.Location:
                    await RepositoryCommon.CheckIfLocationExist(_kasaDbContext, bankAccount.SourceId);
                    break;
                case AccountOwner.Contractor:
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
            if (bankAccount != null)
                return bankAccount;
            else
                throw new Exception($"Bank account with ID: {id} does not exist.");
        }

        public async Task<IEnumerable<BankAccount>> GetBankAccounts(int sourceId, AccountOwner accountOwner)
        {
            return await _kasaDbContext.BankAccounts.Where(c => c.SourceId == sourceId && c.AccountOwner == accountOwner).ToListAsync();
        }

        public async Task Remove(int id)
        {
            var bankAccount = await _kasaDbContext.BankAccounts.FirstOrDefaultAsync(c => c.Id == id);
            if (bankAccount != null)
                try
                {
                    _kasaDbContext.Remove(bankAccount);
                    await _kasaDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
                }
            else
                throw new Exception($"Bank account with ID: {id} does not exist.");
        }

        public async Task Update(BankAccount bankAccount)
        {
            await RepositoryCommon.CheckIfLocationExist(_kasaDbContext, bankAccount.SourceId);
            var bankAccountToUpdate = await _kasaDbContext.BankAccounts.FirstOrDefaultAsync(c => c.Id == bankAccount.SourceId);
            if (bankAccountToUpdate != null)
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
            else
                throw new Exception($"Company with ID: {bankAccount.Id} does not exist.");
        }
    }
}
