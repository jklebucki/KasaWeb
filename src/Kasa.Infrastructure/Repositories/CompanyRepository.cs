using Kasa.Core.Domain;
using Kasa.Core.Repositories;
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
            if (company != null)
                try
                {
                    _kasaDbContext.Companies.Remove(company);
                    await _kasaDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException != null ? ex.InnerException?.Message : ex.Message);
                }
            else
                throw new Exception($"Company with ID: {id} does not exist.");

        }

        public async Task Update(Company company)
        {
            var companyToUpdate = await _kasaDbContext.Companies.FirstOrDefaultAsync(c => c.Id == company.Id);
            if (companyToUpdate != null)
                try
                {
                    companyToUpdate.Update(company.CompanyGroupId,
                                           company.Name,
                                           company.Description,
                                           company.Street,
                                           company.Place,
                                           company.ZipCode,
                                           company.District,
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
            else
                throw new Exception($"Company with {company.Name} with ID: {company.Id} does not exist.");

        }
        public async Task<Company> GetById(int id)
        {
            var company = await _kasaDbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if (company != null)
                return company;
            else
                throw new Exception($"Company with ID: {id} does not exist.");
        }

        public async Task<IEnumerable<Company>> GetByName(string companyName)
        {
            var companies = await _kasaDbContext.Companies.Where(c => c.Name.ToLower().Contains(companyName.ToLower())).ToListAsync();
            return companies;
        }
    }
}
