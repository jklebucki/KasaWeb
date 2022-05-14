using Kasa.Core.Extensions;
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
            DocumentNumber = documentNumber;
        }

        private void SetDocumentSeries(string documentSeries)
        {
            DocumentSeries = documentSeries;
        }

        private void SetCurrencyDesignation(string currencyDesignation)
        {
            CurrencyDesignation = currencyDesignation;
        }

        private void SetCacheOperationType(CashOperationType cashOperationType)
        {
            CashOperationType = cashOperationType;
        }

        private void SetSum(decimal sum)
        {
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
