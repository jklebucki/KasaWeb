using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Repositories
{
    public class CompanyGroupRepository : ICompanyGroupRepository
    {
        private readonly KasaDbContext _kasaDbContext;

        public CompanyGroupRepository(KasaDbContext kasaDbContext)
        {
            _kasaDbContext = kasaDbContext ?? throw new ArgumentNullException(nameof(kasaDbContext));
        }

        public async Task<int> Add(CompanyGroup companyGroup)
        {
            try
            {
                _kasaDbContext.Add(companyGroup);
                await _kasaDbContext.SaveChangesAsync();
                return companyGroup.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
            }
        }
        public async Task Remove(int id)
        {
            var companyGroup = await _kasaDbContext.CompanyGroups.FirstOrDefaultAsync(c => c.Id == id);
            if (companyGroup != null)
                try
                {
                    _kasaDbContext.CompanyGroups.Remove(companyGroup);
                    await _kasaDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
                }
            else
                throw new Exception($"Company group with ID: {id} does not exist.");
        }

        public async Task Update(CompanyGroup companyGroup)
        {
            var companyGropupToUpdate = await _kasaDbContext.CompanyGroups.FirstOrDefaultAsync(c => c.Id == companyGroup.Id);
            if (companyGropupToUpdate != null)
                try
                {
                    companyGropupToUpdate.Update(companyGroup.GroupName);
                    _kasaDbContext.Update(companyGropupToUpdate);
                    await _kasaDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
                }
            else
                throw new Exception($"Company group with ID: {companyGroup.Id} does not exist.");
        }

        public async Task<CompanyGroup> GetById(int id)
        {
            var companyGroup = await _kasaDbContext.CompanyGroups.FirstOrDefaultAsync(c => c.Id == id);
            if (companyGroup != null)
                return companyGroup;
            else
                throw new Exception($"Company group with ID: {id} does not exist.");
        }

        public async Task<IEnumerable<CompanyGroup>> GetByName(string companyGroupName)
            => await _kasaDbContext.CompanyGroups.Where(c => c.GroupName.ToLower().Contains(companyGroupName.ToLower())).ToListAsync();
    }
}
