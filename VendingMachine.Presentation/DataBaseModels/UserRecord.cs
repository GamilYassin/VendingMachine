using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Presentation.DataBaseModels
{
	public class UserRecord
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string UserPassword { get; set; }
		public string Privilege { get; set; }
	}
}