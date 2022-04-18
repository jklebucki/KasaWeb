using Kasa.Core.Domain;

namespace Kasa.Core.Repositories
{
    public interface ICompanyRepository
    {
        Task<int> Add(Company company);
        Task Remove(int id);
        Task Update(Company company);
        Task<Company> GetById(int id);
        Task<IEnumerable<Company>> GetByName(string companyName);
        Task<IEnumerable<Company>> GetByGroupId(int companyGroupId);
    }
}
