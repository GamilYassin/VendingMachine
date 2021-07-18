using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Tables
{
   public class CarItemTableRecord: ITable
    {
        public int SessionId { get; set; }
        public int SellItemId { get; set; }
        public int SellItemQty { get; set; }
    }
}
