using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendingMachine.Presentation.DataBaseModels
{
	public class LocationRecord
	{
		#region Properties

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int VendingMachineId { get; set; }

		[StringLength(50)]
		public string Stret { get; set; }

		[StringLength(50)]
		public string City { get; set; }

		[StringLength(100)]
		public string Landmark { get; set; }

		#endregion Properties
	}
}