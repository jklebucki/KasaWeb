using Kasa.Core.Domain;
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
        private readonly KasaDbContext _kasaDbContext;
        private readonly IUserService _userService;
        public UserController(KasaDbContext kasaDbContext, IUserService userService)
        {
            _kasaDbContext = kasaDbContext;
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            await _userService.CreateAsync(user);
            return Ok();
        }
        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> Get(int companyId)
        {
            var users = await _userService.GetCompanyUsersAsync(companyId);
            return Ok(users);
        }
    }
}