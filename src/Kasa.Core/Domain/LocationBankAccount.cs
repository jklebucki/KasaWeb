namespace Kasa.Core.Domain
{
    public class LocationBankAccount : Entity
    {
        public int LocationId { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        private LocationBankAccount() { }

        public LocationBankAccount(int locationId, string bankName, string bankAccount)
        {
            SetLocationId(locationId);
            SetName(bankName);
            SetBankAccount(bankAccount);
            CreatedAt = DateTime.UtcNow;
        }

        private void SetLocationId(int locationId)
        {
            LocationId = locationId;
        }

        private void SetName(string bankName)
        {
            BankName = bankName;
        }

        private void SetBankAccount(string bankAccount)
        {
            BankAccount = bankAccount;
        }

        public void Update(int locationId, string bankName, string bankAccount)
        {
            SetLocationId(locationId);
            SetName(bankName);
            SetBankAccount(bankAccount);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}