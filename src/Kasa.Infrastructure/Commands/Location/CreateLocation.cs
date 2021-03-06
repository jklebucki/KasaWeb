namespace Kasa.Infrastructure.Commands.Location
{
    public class CreateLocation
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string LocationEmail { get; set; }
        public string LocationPhone { get; set; }
        public string DocumentSeries { get; set; }
    }
}
