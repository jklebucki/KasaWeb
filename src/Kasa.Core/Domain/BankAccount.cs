namespace Kasa.Core.Domain
{
    public enum AccountOwner { Location = 1, Contractor = 2 }
    public class BankAccount : Entity
    {
        public int SourceId { get; protected set; }
        public AccountOwner AccountOwner { get; protected set; }
        public string BankName { get; protected set; }
        public string BankAccountNumber { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        private BankAccount() { }

        public BankAccount(int sourceId, AccountOwner accountOwner, string bankName, string bankAccountNumber)
        {
            SetSourceId(sourceId);
            SetAccountOwner(accountOwner);
            SetName(bankName);
            SetBankAccount(bankAccountNumber);
            CreatedAt = DateTime.UtcNow;
        }

        private void SetSourceId(int sourceId)
        {
            SourceId = sourceId;
        }

        private void SetAccountOwner(AccountOwner accountOwner)
        {
            AccountOwner = accountOwner;
        }

        private void SetName(string bankName)
        {
            BankName = bankName;
        }

        private void SetBankAccount(string bankAccount)
        {
            BankAccountNumber = bankAccount;
        }

        public void Update(int sourceId, AccountOwner accountOwner, string bankName, string bankAccount)
        {
            SetSourceId(sourceId);
            SetAccountOwner(accountOwner);
            SetName(bankName);
            SetBankAccount(bankAccount);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}