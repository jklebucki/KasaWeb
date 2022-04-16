using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Common;
using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Repositories
{
    internal class LocationRepository : ILocationRepository
    {
        private readonly KasaDbContext _kasaDbContext;

        public LocationRepository(KasaDbContext kasaDbContext)
        {
            _kasaDbContext = kasaDbContext;
        }

        public async Task<int> Add(Location location)
        {
            await RepositoryCommon.CheckIfCompanyExist(_kasaDbContext, location.CompanyId);
            _kasaDbContext.Add(location);
            await _kasaDbContext.SaveChangesAsync();
            return location.Id;
        }

        public async Task<Location> GetById(int id)
        {
            var location = await _kasaDbContext.Locations.FirstOrDefaultAsync(l => l.Id == id);
            if (location == null)
                throw new Exception($"Location with ID {id} does not exist.");
            return location;
        }

        public async Task<IEnumerable<Location>> GetByName(string companyName)
        {
            return await _kasaDbContext.Locations.Where(l=>l.Name.ToLower() == companyName.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetComapnyGroupLocations(int companyId)
        {
            return await _kasaDbContext.Locations.Where(l => l.CompanyId == companyId).ToListAsync();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
