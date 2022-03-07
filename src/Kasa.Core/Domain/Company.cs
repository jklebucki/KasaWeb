using Kasa.Core.Extensions;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Kasa.Core.Domain
{
    public class Company : Entity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Street { get; protected set; }
        public string Place { get; protected set; }
        public string ZipCode { get; protected set; }
        public string District { get; protected set; }
        public string Country { get; protected set; }
        public string CompanyEmail { get; protected set; }
        public string CompanyPhone { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        public IEnumerable<Location> Locations { get; protected set; }
        public Company(string name,
                       string description,
                       string street,
                       string place,
                       string zipCode,
                       string district,
                       string country,
                       string companyEmail,
                       string companyPhone)
        {
            SetName(name);
            SetDescription(description);
            SetStreet(street);
            SetPlace(place);
            SetZipCode(zipCode);
            SetDistrict(district);
            SetCountry(country);
            SetCompanyEmail(companyEmail);
            SetCompanyPhone(companyPhone);
            CreatedAt = DateTime.UtcNow;
        }

        private void SetName(string name)
        {
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
        private void SetDistrict(string district)
        {
            District = district;
        }

        private void SetCountry(string country)
        {
            Country = country;
        }
        private void SetCompanyEmail(string companyEmail)
        {
            var result = EntityExtensions.CheckIfEmailIsValid(companyEmail);
            if (result)
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
