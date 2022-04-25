using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Common
{
    public static class RepositoryCommon
    {
        public static async Task CheckIfCompanyGroupExist(KasaDbContext kasaDbContext, int id)
        {
            var companyGroup = await kasaDbContext.CompanyGroups.FirstOrDefaultAsync(cg => cg.Id == id);
            if (companyGroup == null)
                throw new Exception($"Company group with ID {id} does not exist.");
        }
        public static async Task CheckIfCompanyExist(KasaDbContext kasaDbContext, int id)
        {
            var companyGroup = await kasaDbContext.Companies.FirstOrDefaultAsync(cg => cg.Id == id);
            if (companyGroup == null)
                throw new Exception($"Company with ID {id} does not exist.");
        }

        internal static Task CheckIfContractorExist(KasaDbContext kasaDbContext, int sourceId)
        {
            throw new NotImplementedException();
        }

        public static async Task CheckIfLocationExist(KasaDbContext kasaDbContext, int id)
        {
            var location = await kasaDbContext.Locations.FirstOrDefaultAsync(cg => cg.Id == id);
            if (location == null)
                throw new Exception($"Location with ID {id} does not exist.");
        }
    }
}
