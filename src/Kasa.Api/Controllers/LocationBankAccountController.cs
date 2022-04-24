using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Commands.LocationBankAccount;
using Kasa.Infrastructure.DTO;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class LocationBankAccountController : ControllerBase
    {
        private readonly ILocationBankAccountService _locationBankAccountService;
        private readonly IMapper _mapper;

        public LocationBankAccountController(ILocationBankAccountService locationBankAccountService, IMapper mapper)
        {
            _locationBankAccountService = locationBankAccountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var locationBankAccount = await _locationBankAccountService.GetLocationBankAccountById(id);
                return Ok(_mapper.Map<LocationBankAccountDto>(locationBankAccount));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("locationBankAccounts/{locationId}")]
        public async Task<IActionResult> GetByLocationId(int locationId)
        {
            var locationBankAccounts = await _locationBankAccountService.GetLocationBankAccountsByLocationId(locationId);
            return Ok(_mapper.Map<List<LocationBankAccountDto>>(locationBankAccounts));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLocationBankAccount createLocationBankAccount)
        {
            if (createLocationBankAccount == null)
                return BadRequest("CrateLocationBankAccount command is null");
            try
            {
                var locationBankAccount = _mapper.Map<LocationBankAccount>(createLocationBankAccount);
                var newLocationBankAccountId = await _locationBankAccountService.AddLocationBankAccount(locationBankAccount);
                return Created($"LocationBankAccount/{newLocationBankAccountId}", null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _locationBankAccountService.DeleteLocationBankAccount(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(CreateLocationBankAccount createLocationBankAccount)
        {
            if (createLocationBankAccount == null)
                return BadRequest("CreateLocationBankAccount command is null");
            try
            {
                var locationBankAccount = _mapper.Map<LocationBankAccount>(createLocationBankAccount);
                await _locationBankAccountService.UpdateLocationBankAccount(locationBankAccount);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
