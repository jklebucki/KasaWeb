namespace Kasa.Infrastructure.Commands.Users
{
    public class UpdateUser
    {
        public int Id { get; set; }
        public int CompanyGroupId { get; set; }
        public string? Role { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
