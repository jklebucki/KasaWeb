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
        [HttpGet("groups/{groupName}")]
        public async Task<IActionResult> GetByName(string groupName)
        {
            try
            {
                var companyGroup = await _companyGroupService.GetCompanyGroupByName(groupName);
                return Ok(companyGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyGroup(CreateComapanyGroup create)
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

        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyGroup(int id)
        {
            try
            {
                await _companyGroupService.DeleteCompanyGroup(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutCompanyGroup(UpdateCompanyGroup companyGroupData)
        {
            if (companyGroupData == null)
                return BadRequest("Company group object is null.");
            try
            {
                var companyGroup = new CompanyGroup(companyGroupData.Id, companyGroupData.CompanyGroupName);
                await _companyGroupService.UpdateCompanyGroup(companyGroup);
                return Ok();
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
