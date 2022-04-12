using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa.Infrastructure.DTO
{
    public class CompanyDTO
    {
        public int CompanyGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Place { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
    }
}
