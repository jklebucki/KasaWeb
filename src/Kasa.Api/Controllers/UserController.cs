using Kasa.Api.Commands.Users;
using Kasa.Core.Domain;
using Kasa.Core.Repositories;
using Kasa.Infrastructure.Data;
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
        public UserController(KasaDbContext kasaDbContext, IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Register register)
        {
            var user = new User(0,"user", register.Name, register.FirstName, register.LastName, register.Email, register.Password);
            await _userService.CreateAsync(user);
            return Ok();
        }
        [HttpGet("company/{companyGroupId}")]
        public async Task<IActionResult> Get(int companyGroupId)
        {
            var users = await _userService.GetCompanyGroupUsersAsync(companyGroupId);
            return Ok(users);
        }
    }
}