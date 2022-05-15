using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Common;
using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly KasaDbContext _kasaDbContext;

        public LocationRepository(KasaDbContext kasaDbContext)
        {
            _kasaDbContext = kasaDbContext ?? throw new ArgumentNullException(nameof(kasaDbContext));
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
            => await _kasaDbContext.Locations.Where(l => l.Name.ToLower().Contains(companyName.ToLower())).ToListAsync();


        public async Task<IEnumerable<Location>> GetComapnyLocations(int companyId)
            => await _kasaDbContext.Locations.Where(l => l.CompanyId == companyId).ToListAsync();


        public async Task Remove(int id)
        {
            var locationToRemove = await _kasaDbContext.Locations.FirstOrDefaultAsync(_ => _.Id == id);
            if (locationToRemove == null)
                throw new Exception($"Location with ID {id} does not exist.");
            _kasaDbContext.Locations.Remove(locationToRemove);
            await _kasaDbContext.SaveChangesAsync();
        }

        public async Task Update(Location location)
        {
            var locationToUpdate = await _kasaDbContext.Locations.FirstOrDefaultAsync(_ => _.Id == location.Id);
            if (locationToUpdate == null)
                throw new Exception($"Location with ID {location.Id} does not exist.");
            locationToUpdate.Update(location.CompanyId,
                                    location.Name,
                                    location.Description,
                                    location.Street,
                                    location.Place,
                                    location.ZipCode,
                                    location.Province,
                                    location.Country,
                                    location.LocationEmail,
                                    location.LocationPhone,
                                    location.DocumentSeries);
            _kasaDbContext.Locations.Update(locationToUpdate);
            await _kasaDbContext.SaveChangesAsync();
        }
    }
}
