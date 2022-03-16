using Kasa.Core.Domain;
using Kasa.Infrastructure.Data;
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
        public async Task<IActionResult> CreateTestUser()
        {
            _kasaDbContext.Users.Add(new User(0, 1, "admin", "TestUser", "test@test.pl", "PassWord"));
            await _kasaDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetCompanyUsersAsync(1);
            return Ok(users);
        }
    }
}