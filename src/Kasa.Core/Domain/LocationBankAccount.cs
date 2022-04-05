namespace Kasa.Core.Domain
{
    public class LocationBankAccount : Entity
    {
        public int LocationId { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
    }
}