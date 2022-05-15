using Kasa.Core.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class Document : Entity
    {
        public DateTime DocumentDate { get; protected set; }
        public int DocumentNumber { get; protected set; }
        [MaxLength(15)]
        [Required]
        public string DocumentSeries { get; protected set; }
        [MaxLength(8)]
        [Required]
        public string CurrencyDesignation { get; protected set; }
        public CashOperationType CashOperationType { get; protected set; }
        public decimal Sum { get; protected set; }
        public string DocumentContractorJSON { get; protected set; }
        public int CachePointId { get; protected set; }
        public CashPoint CashPoint { get; set; }
        public ICollection<DocumentItem> DocumentItem { get; set; }
        private Document() { }

        public Document(DateTime documentDate,
                        int documentNumber,
                        string documentSeries,
                        string currencyDesignation,
                        CashOperationType cashOperationType,
                        decimal sum,
                        string documentContractorJSON,
                        int cachePointId)
        {
            SetDocumentName(documentDate);
            SetDocumentNumber(documentNumber);
            SetDocumentSeries(documentSeries);
            SetCurrencyDesignation(currencyDesignation);
            SetCacheOperationType(cashOperationType);
            SetSum(sum);
            SetDocumentContractorJSON(documentContractorJSON);
            SetCachePointId(cachePointId);
            SetCreatedAt();
        }
        public Document(DateTime documentDate,
                int documentNumber,
                string documentSeries,
                string currencyDesignation,
                CashOperationType cashOperationType,
                decimal sum,
                Contractor documentContractor,
                int cachePointId)
        {
            SetDocumentName(documentDate);
            SetDocumentNumber(documentNumber);
            SetDocumentSeries(documentSeries);
            SetCurrencyDesignation(currencyDesignation);
            SetCacheOperationType(cashOperationType);
            SetSum(sum);
            SetDocumentContractorJSON(documentContractor);
            SetCachePointId(cachePointId);
            SetCreatedAt();
        }

        private void SetDocumentName(DateTime documentDate)
        {
            DocumentDate = documentDate;
        }

        private void SetDocumentNumber(int documentNumber)
        {
            if (documentNumber < 0)
                throw new Exception("The document number cannot be less than zero.");
            DocumentNumber = documentNumber;
        }

        private void SetDocumentSeries(string documentSeries)
        {
            if (string.IsNullOrWhiteSpace(documentSeries))
                throw new Exception("The document series cannot be empty.");
            DocumentSeries = documentSeries;
        }

        private void SetCurrencyDesignation(string currencyDesignation)
        {
            if (string.IsNullOrWhiteSpace(currencyDesignation))
                throw new Exception("The currency designation cannot be empty.");
            CurrencyDesignation = currencyDesignation;
        }

        private void SetCacheOperationType(CashOperationType cashOperationType)
        {
            CashOperationType = cashOperationType;
        }

        private void SetSum(decimal sum)
        {
            if (sum < 0)
                throw new Exception("The sum of the document cannot be less than zero.");
            Sum = sum;
        }

        private void SetDocumentContractorJSON(string documentContractorJSON)
        {
            if (this.CheckIfContractorDataCorrect(documentContractorJSON))
                DocumentContractorJSON = documentContractorJSON;
            else
                throw new Exception("The contractor's JSON data is invalid.");
        }

        private void SetDocumentContractorJSON(Contractor documentContractor)
        {
            if (documentContractor == null)
                throw new Exception("The contractor's JSON data is null.");
            var contractor = this.SerializeContractor(documentContractor);
            DocumentContractorJSON = contractor;
        }

        private void SetCachePointId(int cachePointId)
        {
            CachePointId = cachePointId;
        }
    }
}
