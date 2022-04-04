namespace Kasa.Core.Domain
{
    public class DestinationSystem : Entity
    {
        public string DestinationName { get; set; }
        public string DestinationSystemType { get; set; }
        public string DestinationSystemLocation { get; set; }
        public string DestinationSystemDatabase { get; set; }
        public string DestinationSystemSchema { get; set; }
        public string DestinationSystemUser { get; set; }
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
        }

        private void SetDestinationName(string destinationName)
        {
            DestinationName = destinationName;
        }
        private void SetDestinationSystemType(string destinationSystemType)
        {
            DestinationSystemType = destinationSystemType;
        }
        private void SetDestinationSystemLocation(string destinationSystemLocation)
        {
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