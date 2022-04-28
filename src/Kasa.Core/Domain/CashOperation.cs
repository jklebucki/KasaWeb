namespace Kasa.Core.Domain
{
    public enum CashOperationType { BO = 0, KP = 1, KW = -1 }
    public class CashOperation
    {
        public int CashPointId { get; protected set; }
        public string Name { get; protected set; }
        public CashOperationType OperationType { get; protected set; }
        public string DebitSideAccount { get; protected set; }
        public string CreditSideAccount { get; protected set; }
        public bool Clearing { get; protected set; }
    }
}
