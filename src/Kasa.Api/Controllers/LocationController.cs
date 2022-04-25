using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Commands.Location;
using Kasa.Infrastructure.DTO;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class LocationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILocationService _locationService;

        public LocationController(IMapper mapper, ILocationService locationService)
        {
            _mapper = mapper;
            _locationService = locationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var location = await _locationService.GetLocationById(id);
                return Ok(_mapper.Map<LocationDto>(location));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("locations/{locationName}")]
        public async Task<IActionResult> GetById(string locationName)
        {
            try
            {
                var location = await _locationService.GetLocationByName(locationName);
                return Ok(_mapper.Map<List<LocationDto>>(location));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("companyLocations/{companyId}")]
        public async Task<IActionResult> GetByCompanyId(int companyId)
        {
            try
            {
                var location = await _locationService.GetCompanyLocations(companyId);
                return Ok(_mapper.Map<List<LocationDto>>(location));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _locationService.DeleteLocation(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLocation createLocation)
        {
            try
            {
                var location = _mapper.Map<Location>(createLocation);
                var newLocationId = await _locationService.AddLocation(location);
                return Created($"location/{newLocationId}", null);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLocation updateLocation)
        {
            if (updateLocation == null)
                return BadRequest("UpdateLocation command is null");
            try
            {
                var location = _mapper.Map<Location>(updateLocation);
                await _locationService.UpdateLocation(location);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
