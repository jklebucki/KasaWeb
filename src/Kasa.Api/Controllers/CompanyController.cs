using AutoMapper;
using Kasa.Api.Commands.Company;
using Kasa.Core.Domain;
using Kasa.Infrastructure.DTO;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyservice;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyservice, IMapper mapper)
        {
            _companyservice = companyservice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _companyservice.GetCompanyById(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(Create create)
        {
            if (create != null)
            {
                var company = new Company(0,
                                          create.CompanyGroupId,
                                          create.Name,
                                          create.Description,
                                          create.Street,
                                          create.Place,
                                          create.ZipCode,
                                          create.District,
                                          create.Country,
                                          create.CompanyEmail,
                                          create.CompanyPhone);
                var newCompanyId = await _companyservice.AddCompany(company);
                return Ok(newCompanyId);
            }
            return BadRequest();
        }
    }
}
