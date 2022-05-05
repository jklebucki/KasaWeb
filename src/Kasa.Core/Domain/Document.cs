using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class Document : Entity
    {
        public DateTime DocumentDate { get; protected set; }
        public int DocumentNumber { get; protected set; }
        [MaxLength(15)]
        public string DocumentSeries { get; protected set; }
        [MaxLength(8)]
        public string CurrencyDesignation { get; protected set; }
        public CashOperationType CashOperationType { get; protected set; }
        public decimal Sum { get; protected set; }
        public string DocumentContractorJSON { get; protected set; }
        public int CachePointId { get; protected set; }
        public CashPoint CashPoint { get; set; }
        public ICollection<DocumentItem> DocumentItem { get; set; }
        private Document() { }

    }
}
