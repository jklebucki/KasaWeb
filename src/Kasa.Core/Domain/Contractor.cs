using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa.Core.Domain
{
    public class Contractor : Entity
    {
        public int? ContractorErpId { get; set; }
        public int? ContractorErpPosition { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string EstateNumber { get; set; }
        public string QuartersNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string VatId { get; set; }
        public string Regon { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
    }
}
