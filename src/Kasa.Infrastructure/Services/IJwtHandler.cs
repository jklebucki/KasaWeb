using Kasa.Infrastructure.DTO;

namespace Kasa.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(int userId, string role);
    }
}