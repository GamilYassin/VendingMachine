using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace VendingMachine.Presentation.DataBaseModels
{
	public class InsideBalanceRecord
	{
		#region Properties

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public int VendingMachineId { get; set; }

		[DefaultValue(0)]
		public int CentCount { get; set; }

		[DefaultValue(0)]
		public int NickelCount { get; set; }

		[DefaultValue(0)]
		public int DimeCount { get; set; }

		[DefaultValue(0)]
		public int QuarterCount { get; set; }

		[DefaultValue(0)]
		public int DollarCount { get; set; }

		[DefaultValue(0)]
		public int FiveDollarCount { get; set; }

		[DefaultValue(0)]
		public int TenDollarCount { get; set; }

		[DefaultValue(0)]
		public int TwentyDollarCount { get; set; }

		#endregion Properties
	}
}