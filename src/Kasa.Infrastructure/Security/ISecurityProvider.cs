namespace Kasa.Infrastructure.Security
{
    public interface ISecurityProvider
    {
        Task<string> EncodePassword(string plainPassword);
        Task<bool> CompareOldPassword(string oldPlainPassword, string oldPasswordHash);
    }
}
