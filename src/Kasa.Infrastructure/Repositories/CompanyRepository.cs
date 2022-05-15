using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Common;
using Kasa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly KasaDbContext _kasaDbContext;

        public CompanyRepository(KasaDbContext kasaDbContext)
        {
            _kasaDbContext = kasaDbContext ?? throw new ArgumentNullException(nameof(kasaDbContext));
        }

        public async Task<int> Add(Company company)
        {
            await RepositoryCommon.CheckIfCompanyGroupExist(_kasaDbContext, company.CompanyGroupId);
            try
            {
                _kasaDbContext.Add(company);
                await _kasaDbContext.SaveChangesAsync();
                return company.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
            }
        }

        public async Task Remove(int id)
        {
            var company = await _kasaDbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if (company == null)
                throw new Exception($"Company with ID: {id} does not exist.");
            try
            {
                _kasaDbContext.Remove(company);
                await _kasaDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
            }
        }

        public async Task Update(Company company)
        {
            await RepositoryCommon.CheckIfCompanyGroupExist(_kasaDbContext, company.CompanyGroupId);
            var companyToUpdate = await _kasaDbContext.Companies.FirstOrDefaultAsync(c => c.Id == company.Id);
            if (companyToUpdate == null)
                throw new Exception($"Company with ID: {company.Id} does not exist.");
            try
            {
                companyToUpdate.Update(company.CompanyGroupId,
                                       company.Name,
                                       company.Description,
                                       company.Street,
                                       company.Place,
                                       company.ZipCode,
                                       company.Province,
                                       company.Country,
                                       company.CompanyEmail,
                                       company.CompanyPhone);
                _kasaDbContext.Update(companyToUpdate);
                await _kasaDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
            }
        }

        public async Task<Company> GetById(int id)
        {
            var company = await _kasaDbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if (company == null)
                throw new Exception($"Company with ID: {id} does not exist.");
            return company;
        }

        public async Task<IEnumerable<Company>> GetByName(string companyName)
            => await _kasaDbContext.Companies.Where(c => c.Name.ToLower().Contains(companyName.ToLower())).ToListAsync();

        public async Task<IEnumerable<Company>> GetByGroupId(int companyGroupId)
            => await _kasaDbContext.Companies.Where(c => c.CompanyGroupId == companyGroupId).ToListAsync();
    }
}
