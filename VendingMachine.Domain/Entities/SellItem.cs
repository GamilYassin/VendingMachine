using System.Collections.Generic;
using VendingMachine.Domain.BaseClasses;
using VendingMachine.SharedKernel.Interfaces;
using VendingMachine.SharedKernel.ValueObjects;


namespace VendingMachine.Domain.Entities
{
	public class SellItem : Entity
	{
		public string Name{get; set;}
		public Money Price{get; set;}
		public string Barcode{get; set;}
		public SellItemType ItemType{get; set;}
		public int GrandTotal{get; set;}
		public Money GrandSellAmount{get; set;}
	}
}