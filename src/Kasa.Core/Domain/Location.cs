namespace Kasa.Core.Domain
{
    public class Location : Entity
    {
        public int CompanyId { get; set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Street { get; protected set; }
        public string Place { get; protected set; }
        public string ZipCode { get; protected set; }
        public string District { get; protected set; }
        public string Country { get; protected set; }
        public string LocationEmail { get; protected set; }
        public string LocationPhone { get; protected set; }
        public string DocumentSeries { get; set; }
        public IEnumerable<LocationBankAccount> BankAccounts { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
    }
}
