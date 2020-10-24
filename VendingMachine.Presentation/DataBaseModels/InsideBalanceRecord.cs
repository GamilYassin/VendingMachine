using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Presentation.DataBaseModels
{
	public class InsideBalanceRecord
	{
		public int VendingMachineId { get; set; }
		public int CentCount { get; set; }
		public int NickelCount { get; set; }
		public int DimeCount { get; set; }
		public int QuarterCount { get; set; }
		public int DollarCount { get; set; }
		public int FiveDollarCount { get; set; }
		public int TenDollarCount { get; set; }
		public int TwentyDollarCount { get; set; }
	}
}