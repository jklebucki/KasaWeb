using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Core.Repositories;

namespace Kasa.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(IMapper mapper, ICompanyRepository userRepository)
        {
            _mapper = mapper;
            _companyRepository = userRepository;
        }

        public async Task<int> AddCompany(Company company)
        {
            return await _companyRepository.Add(company);
        }

        public async Task DeleteCompany(int companyId)
        {
            await _companyRepository.Remove(companyId);
        }

        public async Task UpdateCompany(Company company)
        {
            await _companyRepository.Update(company);
        }
        public async Task<Company> GetCompanyById(int companyId)
        {
            return await _companyRepository.GetById(companyId);
        }

        public async Task<IEnumerable<Company>> GetCompanyByName(string companyName)
        {
            return await _companyRepository.GetByName(companyName);
        }
    }
}
