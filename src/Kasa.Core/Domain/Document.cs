using System.ComponentModel.DataAnnotations.Schema;

namespace Kasa.Core.Domain
{
    public class Document : Entity
    {
        public int CachePointId { get; protected set; }
        public CashPoint CashPoint { get; set; }
        public ICollection<DocumentItem> DocumentItem { get; set; }
        public virtual DocumentContractor DocumentContractor { get; set; }
    }
}
