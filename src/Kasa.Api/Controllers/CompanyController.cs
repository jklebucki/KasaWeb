using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Commands.Company;
using Kasa.Infrastructure.DTO;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyservice, IMapper mapper)
        {
            _companyService = companyservice;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _companyService.GetCompanyById(id);
                return Ok(_mapper.Map<CompanyDto>(company));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("companies/{companyName}")]
        public async Task<IActionResult> GetCompanies(string companyName)
        {
            var companies = await _companyService.GetCompanyByName(companyName);
            return Ok(_mapper.Map<List<CompanyDto>>(companies));
        }

        [HttpGet("companiesInGroup/{companyGroupId}")]
        public async Task<IActionResult> GetAllCompaniesInGroup(int companyGroupId)
        {
            var companies = await _companyService.GetCompanyByGroupId(companyGroupId);
            return Ok(_mapper.Map<List<CompanyDto>>(companies));
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] CreateCompany create)
        {
            if (create != null)
                return BadRequest("Create command is null.");
            try
            {
                var company = _mapper.Map<Company>(create);
                var newCompanyId = await _companyService.AddCompany(company);
                return Created($"/Company/{newCompanyId}", null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                await _companyService.DeleteCompany(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompany updateCompany)
        {
            if (updateCompany == null)
                return BadRequest("UpdateCommand is null.");
            try
            {
                var company = _mapper.Map<Company>(updateCompany);
                await _companyService.UpdateCompany(company);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
