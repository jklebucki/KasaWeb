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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyservice, IMapper mapper)
        {
            _companyService = companyservice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _companyService.GetCompanyById(id);
                return Ok(_mapper.Map<CompanyDTO>(company));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("companies/{companyName}")]
        public async Task<IActionResult> GetCompanies(string companyName)
        {
            var companies = await _companyService.GetCompanyByName(companyName);
            return Ok(_mapper.Map<List<CompanyDTO>>(companies));
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CreateCompany create)
        {
            try
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
                    var newCompanyId = await _companyService.AddCompany(company);
                    return Ok($"/Company/{newCompanyId}");
                }
                return BadRequest("Create command is null.");
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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompany(UpdateCompany updateCompany)
        {
            if (updateCompany == null)
                return BadRequest("UpdateCommand is null.");
            try
            {
                var company = new Company(updateCompany.Id,
                                          updateCompany.CompanyGroupId,
                                          updateCompany.Name,
                                          updateCompany.Description,
                                          updateCompany.Street,
                                          updateCompany.Place,
                                          updateCompany.ZipCode,
                                          updateCompany.District,
                                          updateCompany.Country,
                                          updateCompany.CompanyEmail,
                                          updateCompany.CompanyPhone);
                await _companyService.UpdateCompany(company);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
