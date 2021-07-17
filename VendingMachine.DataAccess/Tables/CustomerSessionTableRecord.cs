using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.DataAccess.Tables
{
   public class CustomerSessionTableRecord
    {
        public int Id { get; set; }
        public int VendingMachineId { get; set; }
        public int BalanceId { get; set; }
        public string Status { get; set; }
    }
}
