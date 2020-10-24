using System;
using VendingMachine.Domain.BaseClasses;
using VendingMachine.SharedKernel.Interfaces;
using VendingMachine.Domain.Enums;
using System.CodeDom;

namespace VendingMachine.Domain.ValueObjects
{
	public class SellItem : ValueObjectBase<SellItem>, IValueObject
	{
		public string Name { get; set; }
		public Money Price { get; set; }
		public string Barcode { get; set; }
		public SellItemType ItemType { get; set; }
		public int GrandTotal { get; set; }
		public Money GrandSellAmount { get; set; }

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

		public override string ToString()
		{
			return $"Item Name: {this.Name} Price: {this.Price.ToString()}";
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, null))
				throw new NullReferenceException();

			SellItem otherItem = (SellItem)obj;
			if (this.Name != otherItem.Name)
				return false;
			if (this.Price != otherItem.Price)
				return false;
			if (this.Barcode != otherItem.Barcode)
				return false;
			if (this.ItemType != otherItem.ItemType)
				return false;
			if (this.GrandTotal != otherItem.GrandTotal)
				return false;
			if (this.GrandSellAmount != otherItem.GrandSellAmount)
				return false;

			return true;
		}

		public override int GetHashCode()
		{
			return this.Name.GetHashCode() *
					this.Barcode.GetHashCode() *
					this.Price.GetHashCode() *
					this.ItemType.GetHashCode() *
					this.GrandTotal.GetHashCode() *
					this.GrandSellAmount.GetHashCode();
		}

		public override SellItem Add(SellItem obj)
		{
			throw new NotImplementedException();
		}

		public override SellItem Subtract(SellItem obj)
		{
			throw new NotImplementedException();
		}
	}
}