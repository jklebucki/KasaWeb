using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Commands.Users;
using Kasa.Infrastructure.DTO;
using Kasa.Infrastructure.Security;
using Kasa.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISecurityProvider _securityProvider;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(ISecurityProvider securityProvider, IUserService userService, IMapper mapper)
        {
            _securityProvider = securityProvider;
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

        [HttpGet("companyGroupUsers/{companyGroupId}")]
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
                register.Password = await _securityProvider.EncodePassword(register.Password);
                var user = _mapper.Map<User>(register);
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

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser updateUser)
        {
            if (updateUser == null)
                return BadRequest("Command UpdateUser is null.");
            try
            {
                var user = _mapper.Map<User>(updateUser);
                await _userService.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword changePassword)
        {
            if (changePassword == null)
                return BadRequest("Command ChangePassword is null.");
            try
            {
                await _userService.ChangePassword(changePassword.Id, changePassword.OldPassword, changePassword.NewPassword);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}