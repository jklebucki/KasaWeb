namespace Kasa.Core.Domain
{
    public class LocationPermission : Entity
    {
        public int UserId { get; set; }
        public int LocalizationId { get; set; }
        public string Role { get; set; }
    }
}