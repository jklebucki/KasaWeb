using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Common;
using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Repositories
{
    public class LocationsBankAccountsRepository : ILocationBankAccountsRepository
    {
        private readonly KasaDbContext _kasaDbContext;

        public LocationsBankAccountsRepository(KasaDbContext kasaDbContext)
        {
            _kasaDbContext = kasaDbContext;
        }

        public async Task<int> Add(LocationBankAccount locationBankAccount)
        {
            _kasaDbContext.Add(locationBankAccount);
            await _kasaDbContext.SaveChangesAsync();
            return locationBankAccount.Id;
        }

        public async Task<LocationBankAccount> GetById(int id)
        {
            var locationBankAccount = await _kasaDbContext.LocationBankAccounts.FirstOrDefaultAsync(c => c.Id == id);
            if (locationBankAccount != null)
                return locationBankAccount;
            else
                throw new Exception($"Bank account with ID: {id} does not exist.");
        }

        public async Task<IEnumerable<LocationBankAccount>> GetLocationBankAccounts(int locationId)
        {
            return await _kasaDbContext.LocationBankAccounts.Where(c => c.LocationId == locationId).ToListAsync();
        }

        public async Task Remove(int id)
        {
            var locationBankAccount = await _kasaDbContext.LocationBankAccounts.FirstOrDefaultAsync(c => c.Id == id);
            if (locationBankAccount != null)
                try
                {
                    _kasaDbContext.Remove(locationBankAccount);
                    await _kasaDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
                }
            else
                throw new Exception($"Bank account with ID: {id} does not exist.");
        }

        public async Task Update(LocationBankAccount locationBankAccount)
        {
            await RepositoryCommon.CheckIfLocationExist(_kasaDbContext, locationBankAccount.LocationId);
            var locationBankAccountToUpdate = await _kasaDbContext.LocationBankAccounts.FirstOrDefaultAsync(c => c.Id == locationBankAccount.LocationId);
            if (locationBankAccountToUpdate != null)
                try
                {
                    locationBankAccountToUpdate.Update(locationBankAccount.Id,
                                                       locationBankAccount.BankName,
                                                       locationBankAccount.BankAccount);
                    _kasaDbContext.Update(locationBankAccountToUpdate);
                    await _kasaDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
                }
            else
                throw new Exception($"Company with ID: {locationBankAccount.Id} does not exist.");
        }
    }
}
