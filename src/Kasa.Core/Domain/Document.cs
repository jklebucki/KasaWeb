namespace Kasa.Core.Domain
{
    public class Document : Entity
    {
        public int CachePointId { get; protected set; }
        public CashPoint CashPoint { get; set; }
        public ICollection<DocumentItem> DocumentItem { get; set; }
    }
}
