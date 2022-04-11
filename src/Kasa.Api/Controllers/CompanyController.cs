using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController: ControllerBase
    {
        private readonly ICompanyService _companyservice;

        public CompanyController(ICompanyService companyservice)
        {
            _companyservice = companyservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _companyservice.GetCompanyById(id);
            return Ok(company);
        } 
    }
}
