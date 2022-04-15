using Kasa.Core.Domain;

namespace Kasa.Infrastructure.Services
{
    public interface ICompanyGroupService
    {
        Task<int> AddCompanyGroup(CompanyGroup companyGroup);
        Task UpdateCompanyGroup(CompanyGroup companyGroup);
        Task DeleteCompanyGroup(int companyGroupId);
        Task<CompanyGroup> GetCompanyGroupById(int companyGroupId);
        Task<IEnumerable<CompanyGroup>> GetCompanyGroupByName(string companyGroupName);
    }
}
