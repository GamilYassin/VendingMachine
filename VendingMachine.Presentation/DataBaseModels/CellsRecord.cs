using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Presentation.DataBaseModels
{
	public class CellsRecord
	{
		public int VendingMachineId { get; set; }
		public string CellId { get; set; }
		public int ItemId { get; set; }
		public int ItemQty { get; set; }
	}
}