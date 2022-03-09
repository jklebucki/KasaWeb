using Kasa.Core.Domain;
using System.Text.RegularExpressions;

namespace Kasa.Core.Extensions
{
    public static class EntityExtensions
    {
        public static bool CheckIfEmailIsValid(this Entity entity, string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
