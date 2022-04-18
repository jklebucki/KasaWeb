using Kasa.Core.Domain;
using Kasa.Core.Repositories;

namespace Kasa.Infrastructure.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<int> AddLocation(Location location)
        {
            return await _locationRepository.Add(location);
        }

        public async Task DeleteLocation(int locationId)
        {
            await _locationRepository.Remove(locationId);
        }

        public async Task<IEnumerable<Location>> GetCompanyLocations(int companyId)
        {
            return await _locationRepository.GetComapnyLocations(companyId);
        }

        public async Task<Location> GetLocationById(int locationId)
        {
            return await _locationRepository.GetById(locationId);
        }

        public async Task<IEnumerable<Location>> GetLocationByName(string locationName)
        {
            return await _locationRepository.GetByName(locationName);
        }

        public Task UpdateLocation(Location location)
        {
            return _locationRepository.Update(location);
        }
    }
}
