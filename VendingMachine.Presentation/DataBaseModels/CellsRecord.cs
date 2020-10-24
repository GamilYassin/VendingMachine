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
	public class CellsRecord
	{
		#region Properties

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int VendingMachineId { get; set; }

		[Required]
		[StringLength(5)]
		public string CellId { get; set; }

		[DefaultValue(-1)]
		public int ItemId { get; set; }

		[DefaultValue(0)]
		public int ItemQty { get; set; }

		#endregion Properties
	}
}