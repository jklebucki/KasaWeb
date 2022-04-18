using Kasa.Infrastructure.DTO;

namespace Kasa.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDTO CreateToken(int userId, string role);
    }
}