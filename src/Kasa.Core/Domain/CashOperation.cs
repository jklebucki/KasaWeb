namespace Kasa.Core.Domain
{
    public enum CashOperationType { BO = 0, KP = 1, KW = -1 }
    public class CashOperation : Entity
    {
        public string Name { get; protected set; }
        public CashOperationType OperationType { get; protected set; }
        public string DebitSideAccount { get; protected set; }
        public string CreditSideAccount { get; protected set; }
        public bool Clearing { get; protected set; }

        public int CashPointId { get; protected set; }
        public CashPoint CashPoint { get; set; }

        public CashOperation(int cashPointId, string name, CashOperationType operationType, string debitSideAccount, string creditSideAccount, bool clearing)
        {
            SetCachePointId(cashPointId);
            SetName(name);
            SetOperationType(operationType);
            SetDebitSideAccount(debitSideAccount);
            SetCreditSideAccount(creditSideAccount);
            SetClearing(clearing);
            SetCreatedAt();
        }

        public void Update(int cashPointId, string name, CashOperationType operationType, string debitSideAccount, string creditSideAccount, bool clearing)
        {
            SetCachePointId(cashPointId);
            SetName(name);
            SetOperationType(operationType);
            SetDebitSideAccount(debitSideAccount);
            SetCreditSideAccount(creditSideAccount);
            SetClearing(clearing);
            SetUpdatedAt();
        }

        private void SetCachePointId(int cashPointId)
        {
            CashPointId = cashPointId;
        }

        private void SetName(string name)
        {
            Name = name;
        }

        private void SetOperationType(CashOperationType operationType)
        {
            OperationType = operationType;
        }

        private void SetDebitSideAccount(string debitSideAccount)
        {
            DebitSideAccount = debitSideAccount;
        }

        private void SetCreditSideAccount(string creditSideAccount)
        {
            CreditSideAccount = creditSideAccount;
        }

        private void SetClearing(bool clearing)
        {
            Clearing = clearing;
        }
    }
}
