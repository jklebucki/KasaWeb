using Kasa.Core.Domain;

namespace Kasa.Core.Repositories
{
    public interface ICompanyGroupRepository
    {
        Task<int> Add(CompanyGroup companyGroup);
        Task Remove(int id);
        Task Update(CompanyGroup companyGroup);
        Task<CompanyGroup> GetById(int id);
        Task<IEnumerable<CompanyGroup>> GetByName(string companyName);
    }
}
