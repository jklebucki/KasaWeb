using Kasa.Core.Domain;
using Kasa.Core.Repositories;

namespace Kasa.Infrastructure.Services
{
    public class LocationBankAccountService : ILocationBankAccountService
    {
        private readonly ILocationBankAccountRepository _locationBankAccountRepository;

        public LocationBankAccountService(ILocationBankAccountRepository locationBankAccountRepository)
        {
            _locationBankAccountRepository = locationBankAccountRepository;
        }

        public async Task<int> AddLocationBankAccount(LocationBankAccount locationBankAccount)
        {
            return await _locationBankAccountRepository.Add(locationBankAccount);
        }

        public async Task DeleteLocationBankAccount(int locationBankAccountId)
        {
            await _locationBankAccountRepository.Remove(locationBankAccountId);
        }

        public async Task<LocationBankAccount> GetLocationBankAccountById(int locationBankAccountId)
        {
            return await _locationBankAccountRepository.GetById(locationBankAccountId);
        }

        public async Task<IEnumerable<LocationBankAccount>> GetLocationBankAccountsByLocationId(int locationId)
        {
            return await _locationBankAccountRepository.GetLocationBankAccounts(locationId);
        }

        public async Task UpdateLocationBankAccount(LocationBankAccount locationBankAccount)
        {
            await _locationBankAccountRepository.Update(locationBankAccount);
        }
    }
}
