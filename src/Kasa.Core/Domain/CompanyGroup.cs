namespace Kasa.Core.Domain
{
    public class CompanyGroup : Entity
    {
        public string GroupName { get; private set; }
        public ICollection<Company> Company { get; set; }
        private CompanyGroup() { }
        public CompanyGroup(int? id, string groupName)
        {
            SetId(id);
            SetGroupName(groupName);
            SetCreatedAt();
        }

        public void Update(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
                throw new Exception($"Company group can not have an empty name.");
            GroupName = groupName;
            SetUpdatedAt();
        }

        private void SetId(int? id)
        {
            if (id == null)
                throw new Exception($"Company group ID cannot be null.");
            Id = (int)id;
        }

        private void SetGroupName(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
                throw new Exception($"Company group can not have an empty name.");
            GroupName = groupName;
        }
    }
}
