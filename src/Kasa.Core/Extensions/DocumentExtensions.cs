using Kasa.Core.Domain;
using System.Text.Json;

namespace Kasa.Core.Extensions
{
    public static class DocumentExtensions
    {
        public static bool CheckIfContractorDataCorrect(this Document document, string contractorDataJSON)
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

        public static string SerializeContractor(this Document document, Contractor contractor)
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

        public static Contractor DserializeContractor(this Document document)
        {
            try
            {
                var contractor = JsonSerializer.Deserialize<Contractor>(document.DocumentContractorJSON);
                if (contractor != null && contractor.GetType() == typeof(Contractor))
                    throw new Exception("The contrator's JSON data is invalid.");
                return contractor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
