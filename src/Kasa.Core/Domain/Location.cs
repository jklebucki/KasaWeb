using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class Location : Entity
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
        public string LocationEmail { get; protected set; }
        [MaxLength(30)]
        public string LocationPhone { get; protected set; }
        [MaxLength(15)]
        public string DocumentSeries { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<CashPoint> CashPoint { get; set; }

        private Location() { }

        public Location(int companyId,
                        string name,
                        string description,
                        string street,
                        string place,
                        string zipCode,
                        string district,
                        string country,
                        string locationEmail,
                        string locationPhone,
                        string documentSeries)
        {
            SetCompanyId(companyId);
            SetName(name);
            SetDescription(description);
            SetStreet(street);
            SetPlace(place);
            SetZipCode(zipCode);
            SetDistrict(district);
            SetCountry(country);
            SetLocationEmail(locationEmail);
            SetLocationPhone(locationPhone);
            SetDocumentSeries(documentSeries);
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(int companyId,
                        string name,
                        string description,
                        string street,
                        string place,
                        string zipCode,
                        string district,
                        string country,
                        string locationEmail,
                        string locationPhone,
                        string documentSeries)
        {
            SetCompanyId(companyId);
            SetName(name);
            SetDescription(description);
            SetStreet(street);
            SetPlace(place);
            SetZipCode(zipCode);
            SetDistrict(district);
            SetCountry(country);
            SetLocationEmail(locationEmail);
            SetLocationPhone(locationPhone);
            SetDocumentSeries(documentSeries);
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetCompanyId(int companyId)
        {
            CompanyId = companyId;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("The location name cannot be empty.");
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

        private void SetLocationEmail(string locationEmail)
        {
            LocationEmail = locationEmail;
        }

        private void SetLocationPhone(string locationPhone)
        {
            LocationPhone = locationPhone;
        }

        private void SetDocumentSeries(string documentSeries)
        {
            DocumentSeries = documentSeries;
        }
    }
}
