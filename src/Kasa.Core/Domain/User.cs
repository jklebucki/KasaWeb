using Kasa.Core.Extensions;
namespace Kasa.Core.Domain
{
    public class User : Entity
    {
        public int CompanyGroupId { get; protected set; }
        public string Role { get; protected set; }
        public string? Name { get; protected set; }
        public string? FirstName { get; protected set; }
        public string? LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        private User() { }
        public User(int companyGroupId,
                    string role,
                    string name,
                    string firstName,
                    string lastName,
                    string email,
                    string password)
        {
            SetCompanyGroupId(companyGroupId);
            SetRole(role);
            SetName(name);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPassword(password);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public User(int? id,
                    int companyGroupId,
                    string role,
                    string name,
                    string firstName,
                    string lastName,
                    string email,
                    string password)
        {
            SetId(id);
            SetCompanyGroupId(companyGroupId);
            SetRole(role);
            SetName(name);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPassword(password);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(int companyGroupId,
            string role,
            string name,
            string firstName,
            string lastName,
            string email,
            string password)
        {
            SetCompanyGroupId(companyGroupId);
            SetRole(role);
            SetName(name);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPassword(password);
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetId(int? id)
        {
            if (id == null)
                throw new Exception($"User ID can not be null.");
            Id = (int)id;
        }
        private void SetRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new Exception($"User can not have an empty role.");
            }
            role = role.ToLowerInvariant();
            if (!ConstantData.UserRoles.Roles.Contains(role))
                throw new Exception($"The {role} role is not allowed.");
            Role = role;
        }

        private void SetCompanyGroupId(int companyGroupId)
        {
            CompanyGroupId = companyGroupId;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception($"User can not have an empty name.");
            Name = name;
        }

        private void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        private void SetLastName(string lastName)
        {
            LastName = lastName;
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
