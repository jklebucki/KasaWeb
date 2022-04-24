using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa.Infrastructure.Commands.LocationBankAccount
{
    public class UpdateLocationBankAccount
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
    }
}
