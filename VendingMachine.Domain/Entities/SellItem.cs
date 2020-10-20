using VendingMachine.Domain.BaseClasses;
using VendingMachine.SharedKernel.ValueObjects;
using VendingMachine.Domain.Enums;

namespace VendingMachine.Domain.Entities
{
	public class SellItem : Entity
	{
		public string Name { get; set; }
		public Money Price { get; set; }
		public string Barcode { get; set; }
		public SellItemType ItemType { get; set; }
		public int GrandTotal { get; set; }
		public Money GrandSellAmount { get; set; }
	}
}