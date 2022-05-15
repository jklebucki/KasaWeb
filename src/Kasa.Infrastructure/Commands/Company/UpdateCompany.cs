namespace Kasa.Infrastructure.Commands.Company
{
    public class UpdateCompany
    {
        public int Id { get; set; }
        public int CompanyGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
    }
}
