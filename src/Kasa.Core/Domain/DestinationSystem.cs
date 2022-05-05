using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class DestinationSystem : Entity
    {
        [MaxLength(200)]
        public string DestinationName { get; set; }
        [MaxLength(200)]
        public string DestinationSystemType { get; set; }
        [MaxLength(200)]
        public string DestinationSystemLocation { get; set; }
        [MaxLength(200)]
        public string DestinationSystemDatabase { get; set; }
        public string DestinationSystemSchema { get; set; }
        [MaxLength(100)]
        public string DestinationSystemUser { get; set; }
        [MaxLength(200)]
        public string DestinationSystemPassword { get; set; }

        private DestinationSystem() { }
        public DestinationSystem(string destinationName,
                                string destinationSystemType,
                                string destinationSystemLocation,
                                string destinationSystemDatabase,
                                string destinationSystemSchema,
                                string destinationSystemUser,
                                string destinationSystemPassword)
        {
            SetDestinationName(destinationName);
            SetDestinationSystemType(destinationSystemType);
            SetDestinationSystemLocation(destinationSystemLocation);
            SetDestinationSystemDatabase(destinationSystemDatabase);
            SetDestinationSystemSchema(destinationSystemSchema);
            SetDestinationSystemUser(destinationSystemUser);
            SetDestinationSystemPassword(destinationSystemPassword);
            SetCreatedAt();
        }

        private void SetDestinationName(string destinationName)
        {
            if (string.IsNullOrWhiteSpace(destinationName))
            {
                throw new Exception($"Destination can not have an empty name.");
            }
            DestinationName = destinationName;
        }
        private void SetDestinationSystemType(string destinationSystemType)
        {
            if (string.IsNullOrWhiteSpace(destinationSystemType))
            {
                throw new Exception($"Destination can not have an empty system type.");
            }
            DestinationSystemType = destinationSystemType;
        }
        private void SetDestinationSystemLocation(string destinationSystemLocation)
        {
            if (string.IsNullOrWhiteSpace(destinationSystemLocation))
            {
                throw new Exception($"Destination can not have an empty location.");
            }
            DestinationSystemLocation = destinationSystemLocation;
        }

        private void SetDestinationSystemDatabase(string destinationSystemDatabase)
        {
            DestinationSystemDatabase = destinationSystemDatabase;
        }

        private void SetDestinationSystemSchema(string destinationSystemSchema)
        {
            DestinationSystemSchema = destinationSystemSchema;
        }

        private void SetDestinationSystemUser(string destinationSystemUser)
        {
            DestinationSystemUser = destinationSystemUser;
        }

        private void SetDestinationSystemPassword(string destinationSystemPassword)
        {
            DestinationSystemPassword = destinationSystemPassword;
        }
    }

}