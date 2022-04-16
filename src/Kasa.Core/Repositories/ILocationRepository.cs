using Kasa.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa.Core.Repositories
{
    public interface ILocationRepository
    {
        Task<int> Add(Location location);
        Task Remove(int id);
        Task Update(Location location);
        Task<Location> GetById(int id);
        Task<IEnumerable<Location>> GetComapnyGroupLocations(int companyId);
        Task<IEnumerable<Location>> GetByName(string companyName);
    }
}
