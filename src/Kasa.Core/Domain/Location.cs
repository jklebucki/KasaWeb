namespace Kasa.Core.Domain
{
    public class Location : Entity
    {
        public int CompanyId { get; set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Street { get; protected set; }
        public string Place { get; protected set; }
        public string ZipCode { get; protected set; }
        public string District { get; protected set; }
        public string Country { get; protected set; }
        public string LocationEmail { get; protected set; }
        public string LocationPhone { get; protected set; }
        public string DocumentSeries { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
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
