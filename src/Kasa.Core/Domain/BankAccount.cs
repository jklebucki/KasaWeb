using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public enum AccountOwnerType { Location = 1, Contractor = 2 }
    public class BankAccount : Entity
    {
        public int SourceId { get; protected set; }
        public AccountOwnerType AccountOwner { get; protected set; }
        [MaxLength(200)]
        [Required]
        public string BankName { get; protected set; }
        [MaxLength(50)]
        [Required]
        public string BankAccountNumber { get; protected set; }
        private BankAccount() { }

        public BankAccount(int sourceId, AccountOwnerType accountOwnerType, string bankName, string bankAccountNumber)
        {
            SetSourceId(sourceId);
            SetAccountOwner(accountOwnerType);
            SetName(bankName);
            SetBankAccount(bankAccountNumber);
            SetCreatedAt();
        }

        private void SetSourceId(int sourceId)
        {
            SourceId = sourceId;
        }

        private void SetAccountOwner(AccountOwnerType accountOwnerType)
        {
            AccountOwner = accountOwnerType;
        }

        private void SetName(string bankName)
        {
            BankName = bankName;
        }

        private void SetBankAccount(string bankAccount)
        {
            BankAccountNumber = bankAccount;
        }

        public void Update(int sourceId, AccountOwnerType accountOwnerType, string bankName, string bankAccount)
        {
            SetSourceId(sourceId);
            SetAccountOwner(accountOwnerType);
            SetName(bankName);
            SetBankAccount(bankAccount);
            SetUpdatedAt();
        }
    }
}