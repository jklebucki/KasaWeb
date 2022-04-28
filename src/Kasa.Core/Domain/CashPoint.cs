namespace Kasa.Core.Domain
{
    public class CashPoint : Entity
    {
        public string Name { get; protected set; }
        public string Symbol { get; protected set; }
        public bool IsFifo { get; protected set; }
        public bool IsCurrecy { get; protected set; }
        public string AccountNumber { get; protected set; }
    }
}
