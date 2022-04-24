namespace Kasa.Infrastructure.Commands.LocationBankAccount
{
    public class UpdateLocationBankAccount
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
    }
}
