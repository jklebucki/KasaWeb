using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.DTO;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
    }
}
