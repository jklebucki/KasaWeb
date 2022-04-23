using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa.Infrastructure.DTO
{
    public class LocationBankAccountDto
    {
        public int LocationId { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
    }
}
