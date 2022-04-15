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

        public async Task UpdateCompanyGroup(CompanyGroup companyGroup)
        {
            await _companyGroupRepository.Update(companyGroup);
        }
        public async Task DeleteCompanyGroup(int companyGroupId)
        {
            await _companyGroupRepository.Remove(companyGroupId);
        }

        public async Task<CompanyGroup> GetCompanyGroupById(int companyGroupId)
        {
            return await _companyGroupRepository.GetById(companyGroupId);
        }

        public Task<IEnumerable<CompanyGroup>> GetCompanyGroupByName(string companyGroupName)
        {
            return _companyGroupRepository.GetByName(companyGroupName);
        }
    }
}
