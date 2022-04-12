using Kasa.Core.Domain;

namespace Kasa.Infrastructure.Services
{
    public interface ICompanyService
    {
        Task<int> AddCompany(Company company);
        Task UpdateCompany(Company company);
        Task DeleteCompany(int companyId);
        Task<Company> GetCompanyById(int companyId);
        Task<IEnumerable<Company>> GetCompanyByName(string companyName);
    }
}
