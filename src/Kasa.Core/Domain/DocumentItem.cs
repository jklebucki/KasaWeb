namespace Kasa.Core.Domain
{
    public class DocumentItem : Entity
    {
        public int DcumentId { get; protected set; }
        public Document Document { get; set; }
    }
}
