using Kasa.Core.Domain;

namespace Kasa.Infrastructure.Commands.BankAccount
{
    public class UpdateBankAccount
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public AccountOwner AccountOwner { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
