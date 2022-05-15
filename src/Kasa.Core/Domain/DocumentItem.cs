using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class DocumentItem : Entity
    {
        [MaxLength(200)]
        [Required]
        public string Description { get; protected set; }
        public decimal Amount { get; protected set; }
        public int DcumentId { get; protected set; }
        public Document Document { get; set; }

        public DocumentItem(string description, decimal amount, int dcumentId)
        {
            SetDescription(description);
            SetAmount(amount);
            SetDocumentId(dcumentId);
        }

        private void SetDocumentId(int dcumentId)
        {
            DcumentId = dcumentId;
        }

        private void SetAmount(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("The amount should be greater than zero.");
            Amount = amount;
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new Exception("The description cannot be empty.");
            Description = description;
        }
    }
}
