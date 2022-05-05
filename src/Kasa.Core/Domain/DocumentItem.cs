using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class DocumentItem : Entity
    {
        [MaxLength(200)]
        public string Description { get; protected set; }
        public decimal Amount { get; protected set; }
        public int DcumentId { get; protected set; }
        public Document Document { get; set; }
    }
}
