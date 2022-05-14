using Kasa.Core.Domain;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        public static bool CheckIfContractorDataCorrect(this Entity entity, string contractorDataJSON)
        {
            try
            {
                var contractor = JsonSerializer.Deserialize<Contractor>(contractorDataJSON);
                if (contractor != null && contractor.GetType() == typeof(Contractor))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string SerializeContractor(this Entity entity, Contractor contractor)
        {
            try
            {
                return JsonSerializer.Serialize(contractor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
