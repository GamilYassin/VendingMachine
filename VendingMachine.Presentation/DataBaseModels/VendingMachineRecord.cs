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
	public class VendingMachineRecord
	{
		#region Properties

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[StringLength(50)]
		public string Model { get; set; }

		[StringLength(50)]
		public string Manufacturer { get; set; }

		[DefaultValue(90)]
		public int Frequency { get; set; }

		[DefaultValue("getutcdate()")]
		public DateTime LastMaintDate { get; set; }

		public string GrandBalance { get; set; }

		[DefaultValue("getutcdate()")]
		public DateTime StartDate { get; set; }

		[DefaultValue("getutcdate()")]
		public DateTime EndOfLifeDate { get; set; }

		[DefaultValue("Starting")]
		public string State { get; set; }

		#endregion Properties
	}
}