using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class CashPoint : Entity
    {
        [MaxLength(200)]
        public string Name { get; protected set; }
        [MaxLength(20)]
        public string DocumentSymbol { get; protected set; }
        public bool IsFifo { get; protected set; }
        public bool IsCurrecy { get; protected set; }
        [MaxLength(100)]
        public string AccountingAccountNumber { get; protected set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<CashOperation> CashOperation { get; set; }
        public ICollection<Document> Document { get; set; }


        private CashPoint() { }
        public CashPoint(int locationId, string name, string documentSymbol, bool isFifo, bool isCurrecy, string accountingAccountNumber)
        {
            SetLocationId(locationId);
            SetName(name);
            SetDocumentSymbol(documentSymbol);
            SetIsFifo(isFifo);
            SetIsCurrency(isCurrecy);
            SetAccountingAccountNumber(accountingAccountNumber);
            SetCreatedAt();
        }

        private void SetLocationId(int locationId)
        {
            LocationId = locationId;
        }

        public void Update(string name, string documentSymbol, bool isFifo, bool isCurrecy, string accountingAccountNumber)
        {
            SetName(name);
            SetDocumentSymbol(documentSymbol);
            SetIsFifo(isFifo);
            SetIsCurrency(isCurrecy);
            SetAccountingAccountNumber(accountingAccountNumber);
            SetUpdatedAt();
        }


        private void SetName(string name)
        {
            Name = name;
        }

        private void SetDocumentSymbol(string documentSymbol)
        {
            DocumentSymbol = documentSymbol;
        }

        private void SetIsFifo(bool isFifo)
        {
            IsFifo = isFifo;
        }

        private void SetIsCurrency(bool isCurrecy)
        {
            IsCurrecy = isCurrecy;
        }

        private void SetAccountingAccountNumber(string accountingAccountNumber)
        {
            AccountingAccountNumber = accountingAccountNumber;
        }
    }
}
