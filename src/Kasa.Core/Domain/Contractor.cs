using Kasa.Core.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class Contractor : Entity
    {
        public int? ContractorErpId { get; set; }
        public int? ContractorErpPosition { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Street { get; set; }
        [MaxLength(20)]
        public string EstateNumber { get; set; }
        [MaxLength(20)]
        public string ApartmentNumber { get; set; }
        [MaxLength(200)]
        public string Place { get; set; }
        [MaxLength(20)]
        public string ZipCode { get; set; }
        [MaxLength(100)]
        public string Province { get; set; }
        [MaxLength(50)]
        public string VatId { get; set; }
        [MaxLength(50)]
        public string Regon { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(5)]
        public string CountryCode { get; set; }
        private Contractor() { }
        public Contractor(int? contractorErpId, int? contractorErpPosition, string name, string street, string estateNumber, string apartmentNumber, string place, string zipCode, string province, string vatId, string regon, string phone, string email, string countryCode)
        {
            SetContractorErpPosition(contractorErpPosition);
            SetContractorErpId(contractorErpId);
            SetName(name);
            SetStreet(street);
            SetEstateNumber(estateNumber);
            SetQuatersNumber(apartmentNumber);
            SetPlace(place);
            SetZipCode(zipCode);
            SetProvince(province);
            SetVatId(vatId);
            SetRegon(regon);
            SetPhone(phone);
            SetEmail(email);
            SetCountryCode(countryCode);
            SetCreatedAt();
        }
        public void Update(int? contractorErpId, int? contractorErpPosition, string name, string street, string estateNumber, string apartmentNumber, string place, string zipCode, string province, string vatId, string regon, string phone, string email, string countryCode)
        {
            SetContractorErpPosition(contractorErpPosition);
            SetContractorErpId(contractorErpId);
            SetName(name);
            SetStreet(street);
            SetEstateNumber(estateNumber);
            SetQuatersNumber(apartmentNumber);
            SetPlace(place);
            SetZipCode(zipCode);
            SetProvince(province);
            SetVatId(vatId);
            SetRegon(regon);
            SetPhone(phone);
            SetEmail(email);
            SetCountryCode(countryCode);
            SetUpdatedAt();
        }

        private void SetContractorErpPosition(int? contractorErpPosition)
        {
            ContractorErpPosition = contractorErpPosition;
        }

        private void SetContractorErpId(int? contractorErpId)
        {
            ContractorErpId = contractorErpId;
        }

        private void SetName(string name)
        {
            Name = name;
        }

        private void SetStreet(string street)
        {
            Street = street;
        }

        private void SetEstateNumber(string estateNumber)
        {
            EstateNumber = estateNumber;
        }

        private void SetQuatersNumber(string apartmentNumber)
        {
            ApartmentNumber = apartmentNumber;
        }

        private void SetPlace(string place)
        {
            Place = place;
        }

        private void SetZipCode(string zipCode)
        {
            ZipCode = zipCode;
        }

        private void SetProvince(string province)
        {
            Province = province;
        }

        private void SetVatId(string vatId)
        {
            VatId = vatId;
        }

        private void SetRegon(string regon)
        {
            Regon = regon;
        }

        private void SetPhone(string phone)
        {
            Phone = phone;
        }

        private void SetEmail(string email)
        {
            if (!this.CheckIfEmailIsValid(email))
                throw new Exception($"Email {email} is not valid.");
            Email = email;
        }

        private void SetCountryCode(string countryCode)
        {
            CountryCode = countryCode;
        }
    }
}
