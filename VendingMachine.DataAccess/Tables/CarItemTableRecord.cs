using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.DataAccess.Tables
{
   public class CarItemTableRecord
    {
        public int SessionId { get; set; }
        public int SellItemId { get; set; }
        public int SellItemQty { get; set; }
    }
}
