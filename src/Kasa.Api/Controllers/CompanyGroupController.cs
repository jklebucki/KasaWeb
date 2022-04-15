using AutoMapper;
using Kasa.Api.Commands.CompanyGroup;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyGroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyGroupService _companyGroupService;

        public CompanyGroupController(IMapper mapper, ICompanyGroupService companyGroupService)
        {
            _mapper = mapper;
            _companyGroupService = companyGroupService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var companyGroup = await _companyGroupService.GetCompanyGroupById(id);
                return Ok(companyGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CreateComapanyGroup create)
        {
            try
            {
                if (create != null)
                {
                    var companyGroup = new CompanyGroup(0, create.GroupName);
                    var newCompanyGroupId = await _companyGroupService.AddCompanyGroup(companyGroup);
                    return Ok($"/CompanyGroup/{newCompanyGroupId}");
                }
                return BadRequest("Create command is null.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
