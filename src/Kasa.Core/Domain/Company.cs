using Kasa.Core.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class Company : Entity
    {
        [MaxLength(200)]
        [Required]
        public string Name { get; protected set; }
        [MaxLength(200)]
        public string Description { get; protected set; }
        [MaxLength(200)]
        public string Street { get; protected set; }
        [MaxLength(200)]
        public string Place { get; protected set; }
        [MaxLength(20)]
        public string ZipCode { get; protected set; }
        [MaxLength(100)]
        public string Province { get; protected set; }
        [MaxLength(50)]
        public string Country { get; protected set; }
        [MaxLength(100)]
        public string CompanyEmail { get; protected set; }
        [MaxLength(30)]
        public string CompanyPhone { get; protected set; }

        public int CompanyGroupId { get; protected set; }
        public CompanyGroup CompanyGroup { get; set; }
        public ICollection<Location> Location { get; set; }
        private Company() { }
        public Company(int companyGroupId,
                       string name,
                       string description,
                       string street,
                       string place,
                       string zipCode,
                       string district,
                       string country,
                       string companyEmail,
                       string companyPhone)
        {
            SetCompanyGroupId(companyGroupId);
            SetName(name);
            SetDescription(description);
            SetStreet(street);
            SetPlace(place);
            SetZipCode(zipCode);
            SetDistrict(district);
            SetCountry(country);
            SetCompanyEmail(companyEmail);
            SetCompanyPhone(companyPhone);
            SetCreatedAt();
        }

        public void Update(int companyGroupId,
                            string name,
                            string description,
                            string street,
                            string place,
                            string zipCode,
                            string district,
                            string country,
                            string companyEmail,
                            string companyPhone)
        {
            SetCompanyGroupId(companyGroupId);
            SetName(name);
            SetDescription(description);
            SetStreet(street);
            SetPlace(place);
            SetZipCode(zipCode);
            SetDistrict(district);
            SetCountry(country);
            SetCompanyEmail(companyEmail);
            SetCompanyPhone(companyPhone);
            SetUpdatedAt();
        }
        private void SetCompanyGroupId(int companyGroupId)
        {
            CompanyGroupId = companyGroupId;
        }
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("The company name cannot be empty.");
            Name = name;
        }
        private void SetDescription(string description)
        {
            Description = description;
        }
        private void SetStreet(string street)
        {
            Street = street;
        }
        private void SetPlace(string place)
        {
            Place = place;
        }
        private void SetZipCode(string zipCode)
        {
            ZipCode = zipCode;
        }
        private void SetDistrict(string province)
        {
            Province = province;
        }
        private void SetCountry(string country)
        {
            Country = country;
        }
        private void SetCompanyEmail(string companyEmail)
        {
            if (this.CheckIfEmailIsValid(companyEmail))
                CompanyEmail = companyEmail;
            else
                throw new Exception($"Email {companyEmail} is not valid.");
        }
        private void SetCompanyPhone(string companyPhone)
        {
            CompanyPhone = companyPhone;
        }
    }
}
