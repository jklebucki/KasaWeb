using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Core.Repositories;

namespace Kasa.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _userRepository;

        public CompanyService(IMapper mapper, ICompanyRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task AddCompany(Company company)
        {
            await _userRepository.Add(company);
        }

        public async Task DeleteCompany(int companyId)
        {
            await _userRepository.Remove(companyId);
        }

        public async Task UpdateCompany(Company company)
        {
            await _userRepository.Update(company);
        }
        public async Task<Company> GetCompanyById(int companyId)
        {
            return await _userRepository.GetById(companyId);
        }

        public async Task<IEnumerable<Company>> GetCompanyByName(string companyName)
        {
            return await _userRepository.GetByName(companyName);
        }
    }
}
