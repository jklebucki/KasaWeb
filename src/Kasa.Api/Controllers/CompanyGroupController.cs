using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Commands.CompanyGroup;
using Kasa.Infrastructure.DTO;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CompanyGroupController : ControllerBase
    {
        private readonly ICompanyGroupService _companyGroupService;
        private readonly IMapper _mapper;

        public CompanyGroupController(ICompanyGroupService companyGroupService, IMapper mapper)
        {
            _mapper = mapper;
            _companyGroupService = companyGroupService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var companyGroup = await _companyGroupService.GetCompanyGroupById(id);
                return Ok(_mapper.Map<CompanyGroupDto>(companyGroup));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("groups/{groupName}")]
        public async Task<IActionResult> GetByName(string groupName)
        {
            try
            {
                var companyGroups = await _companyGroupService.GetCompanyGroupByName(groupName);
                return Ok(_mapper.Map<IEnumerable<CompanyGroupDto>>(companyGroups));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyGroup([FromBody] CreateComapanyGroup create)
        {
            if (create == null)
                return BadRequest("Create command is null.");
            try
            {

                var companyGroup = new CompanyGroup(0, create.GroupName);
                var newCompanyGroupId = await _companyGroupService.AddCompanyGroup(companyGroup);
                return Created($"/CompanyGroup/{newCompanyGroupId}", null);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyGroup(int id)
        {
            try
            {
                await _companyGroupService.DeleteCompanyGroup(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutCompanyGroup([FromBody] UpdateCompanyGroup companyGroupData)
        {
            if (companyGroupData == null)
                return BadRequest("Company group object is null.");
            try
            {
                var companyGroup = new CompanyGroup(companyGroupData.Id, companyGroupData.CompanyGroupName);
                await _companyGroupService.UpdateCompanyGroup(companyGroup);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
