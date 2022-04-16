using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Commands.Users;
using Kasa.Infrastructure.DTO;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                var user = await _userService.GetAsync(userId).ConfigureAwait(false);
                return Ok(_mapper.Map<UserDto>(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("companyusers/{companyGroupId}")]
        public async Task<IActionResult> GetCompanyGroupUsers(int companyGroupId)
        {
            var users = await _userService.GetCompanyGroupUsersAsync(companyGroupId).ConfigureAwait(false);
            return Ok(_mapper.Map<List<UserDto>>(users));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Register register)
        {
            try
            {
                User user = new(register.CompanyGroupId,
                                        register.Role,
                                        register.Name,
                                        register.FirstName,
                                        register.LastName,
                                        register.Email,
                                        register.Password);
                var userId = await _userService.CreateAsync(user).ConfigureAwait(false);
                return Ok($"/User/{userId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                await _userService.Remove(userId).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}