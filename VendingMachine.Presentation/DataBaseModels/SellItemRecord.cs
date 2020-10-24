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
	public class SellItemRecord
	{
		#region Properties

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		[StringLength(50)]
		public string Price { get; set; }

		[StringLength(20)]
		public string Barcode { get; set; }

		[DefaultValue("Food")]
		[MaxLength(50)]
		public string ItemType { get; set; }

		public int GrandTotal { get; set; }

		[StringLength(50)]
		public string GrandSellAmount { get; set; }

		#endregion Properties
	}
}