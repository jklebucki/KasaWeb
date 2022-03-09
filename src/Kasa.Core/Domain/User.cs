using Kasa.Core.Extensions;
namespace Kasa.Core.Domain
{
    public class User : Entity
    {
        public int CompanyId { get; protected set; }
        public string Role { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        private readonly IEnumerable<string> _roles;
        private readonly IEnumerable<int> _companiesIds;
        public User(int companyId, string role, string name, string email, string password, IEnumerable<string> roles, IEnumerable<int> companiesIds)
        {
            _roles = roles;
            _companiesIds = companiesIds;
            SetCompanyId(companyId);
            SetRole(role);
            SetName(name);
            SetEmail(email);
            SetPassword(password);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public User(int id, int companyId, string role, string name, string email, string password, IEnumerable<string> roles, IEnumerable<int> companiesIds)
        {
            Id = id;
            _roles = roles;
            _companiesIds = companiesIds;
            SetCompanyId(companyId);
            SetRole(role);
            SetName(name);
            SetEmail(email);
            SetPassword(password);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new Exception($"User can not have an empty role.");
            }
            role = role.ToLowerInvariant();
            if (!_roles.Contains(role))
            {
                throw new Exception($"User can not have a role: '{role}'.");
            }
            Role = role;
        }
        private void SetCompanyId(int companyId)
        {
            if (!_companiesIds.Contains(companyId))
            {
                throw new Exception($"Company with id: '{companyId}' does not exist.");
            }
            CompanyId = companyId;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception($"User can not have an empty name.");
            Name = name;
        }

        private void SetEmail(string email)
        {
            if (!this.CheckIfEmailIsValid(email))
                throw new Exception($"Email {email} is not valid.");
            Email = email;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception($"User can not have an empty password.");
            Password = password;
        }
    }
}
