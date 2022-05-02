using System.ComponentModel.DataAnnotations.Schema;

namespace Kasa.Core.Domain
{
    public class DocumentContractor : Entity
    {
        public string Name { get; protected set; }
        public string Street { get; protected set; }
        public string EstateNumber { get; protected set; }
        public string QuartersNumber { get; protected set; }
        public string City { get; protected set; }
        public string ZipCode { get; protected set; }
        public string Province { get; protected set; }
        public string VatId { get; protected set; }
        public string Regon { get; protected set; }
        public string Phone { get; protected set; }
        public string Email { get; protected set; }
        public string CountryCode { get; protected set; }
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public int DocumentId { get; set; }
        public virtual Document Document { get; set; }
    }
}
