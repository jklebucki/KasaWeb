using Kasa.Core.Domain;

namespace Kasa.Infrastructure.Services
{
    public interface ILocationService
    {
        Task<int> AddLocation(Location location);
        Task UpdateLocation(Location location);
        Task DeleteLocation(int locationId);
        Task<Location> GetLocationById(int locationId);
        Task<IEnumerable<Location>> GetLocationByName(string locationName);
        Task<IEnumerable<Location>> GetCompanyLocations(int companyId);
    }
}
