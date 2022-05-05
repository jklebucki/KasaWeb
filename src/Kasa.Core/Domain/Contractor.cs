using System.ComponentModel.DataAnnotations;

namespace Kasa.Core.Domain
{
    public class Contractor : Entity
    {
        public int? ContractorErpId { get; set; }
        public int? ContractorErpPosition { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Street { get; set; }
        [MaxLength(20)]
        public string EstateNumber { get; set; }
        [MaxLength(20)]
        public string QuartersNumber { get; set; }
        [MaxLength(200)]
        public string Place { get; set; }
        [MaxLength(20)]
        public string ZipCode { get; set; }
        [MaxLength(100)]
        public string Province { get; set; }
        [MaxLength(50)]
        public string VatId { get; set; }
        [MaxLength(50)]
        public string Regon { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(5)]
        public string CountryCode { get; set; }
    }
}
