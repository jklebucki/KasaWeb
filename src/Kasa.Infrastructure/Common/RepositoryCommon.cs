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
    }
}
