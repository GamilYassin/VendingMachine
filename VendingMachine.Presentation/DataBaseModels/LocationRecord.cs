using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Presentation.DataBaseModels
{
	public class LocationRecord
	{
		public int VendingMachineId { get; set; }
		public string Stret { get; set; }
		public string City { get; set; }
		public string Landmark { get; set; }
	}
}