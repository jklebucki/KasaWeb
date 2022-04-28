namespace Kasa.Infrastructure.DTO
{
    public class LocationDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string LocationEmail { get; set; }
        public string LocationPhone { get; set; }
        public string DocumentSeries { get; set; }
    }
}
