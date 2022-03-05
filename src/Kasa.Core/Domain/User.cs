using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa.Core.Domain
{
    public class User : Entity
    {
        public string Role { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        private readonly IEnumerable<string> _roles;

        public User(int id, string role, string name, string email, string password, IEnumerable<string> roles)
        {
            Id = id;
            SetRole(role);
            SetName(name);
            SetEmail(email);
            SetPassword(password);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            _roles = roles;
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
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"User can not have an empty name.");
            }
            Name = name;
        }
        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception($"User can not have an empty email.");
            }
            Email = email;
        }
        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception($"User can not have an empty password.");
            }
            Password = password;
        }
    }
}
