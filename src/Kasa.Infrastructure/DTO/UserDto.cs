namespace Kasa.Infrastructure.DTO
{
    public class UserDto
    {
        public int CompanyId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}