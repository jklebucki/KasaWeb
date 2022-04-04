using System.Collections;

namespace Kasa.Core.Domain
{
    public class LocationConfig : Entity
    {
        public int LocationId { get; set; }
        public int DestinationSystemId { get; set; } 
    }
}
