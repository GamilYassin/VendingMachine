using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.BaseClasses;

namespace VendingMachine.Domain.Entities
{
	public class Cell : Entity
	{
		public int RowNumber{get; set;}
		public int LaneNumber {get; set;}
		public SellItem SellItem{get; set;}
		public int SellItemQty{get; set;}
	}
}