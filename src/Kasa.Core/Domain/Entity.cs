namespace Kasa.Core.Domain
{
    public class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        internal void SetCreatedAt()
        {
            CreatedAt = DateTime.UtcNow;
        }
        internal void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
