using System.Text;

namespace Kasa.Infrastructure.Security
{
    public class SecurityProviderBase : ISecurityProvider
    {
        public async Task<bool> CompareOldPassword(string oldPlainPassword, string oldPasswordHash)
        {
            var oldPlainPass = await EncodePassword(oldPlainPassword);
            return oldPlainPass.Equals(oldPasswordHash);
        }

        public async Task<string> EncodePassword(string plainPassword)
        {
            return await Task.FromResult(Convert.ToBase64String(Encoding.UTF8.GetBytes(plainPassword)));
        }
    }
}
