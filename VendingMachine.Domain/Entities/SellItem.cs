using System;
using VendingMachine.Domain.BaseClasses;
using VendingMachine.SharedKernel.Interfaces;
using VendingMachine.Domain.Enums;
using System.CodeDom;

namespace VendingMachine.Domain.ValueObjects
{
	public class SellItem : EntityBase
	{
		#region Constructors

		public SellItem()
		{
		}

		public SellItem(string name, Money price, string barCode, SellItemType itemType, int grandTotal, Money grandAmount)
		{
			this.Name = name;
			this.Price = price;
			this.Barcode = barCode;
			this.ItemType = itemType;
			this.GrandTotal = grandTotal;
			this.GrandSellAmount = grandAmount;
		}

		public SellItem(string name) : this(name, new Money(), String.Empty, SellItemType.Food, 0, new Money())
		{
		}

		#endregion Constructors

		#region Properties

		public string Name { get; set; }
		public Money Price { get; set; }
		public string Barcode { get; set; }
		public SellItemType ItemType { get; set; }
		public int GrandTotal { get; set; }
		public Money GrandSellAmount { get; set; }

		#endregion Properties

		#region Methods

		public override string ToString()
		{
			return $"Item Name: {this.Name} Price: {this.Price.ToString()}";
		}

		#endregion Methods
	}
}