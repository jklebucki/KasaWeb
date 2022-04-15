using Kasa.Core.Domain;
using Kasa.Core.Repositories;

namespace Kasa.Infrastructure.Services
{
    public class CompanyGroupService : ICompanyGroupService
    {
        private readonly ICompanyGroupRepository _companyGroupRepository;

        public CompanyGroupService(ICompanyGroupRepository companyGroupRepository)
        {
            _companyGroupRepository = companyGroupRepository;
        }

        public async Task<int> AddCompanyGroup(CompanyGroup companyGroup)
        {
            var companyGroupId = await _companyGroupRepository.Add(companyGroup);
            return companyGroupId;
        }

        public Task UpdateCompanyGroup(CompanyGroup companyGroup)
        {
            throw new NotImplementedException();
        }
        public Task DeleteCompanyGroup(int companyGroupId)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyGroup> GetCompanyGroupById(int companyGroupId)
        {
            return await _companyGroupRepository.GetById(companyGroupId);
        }

        public Task<IEnumerable<CompanyGroup>> GetCompanyGroupByName(string companyGroupName)
        {
            throw new NotImplementedException();
        }
    }
}
