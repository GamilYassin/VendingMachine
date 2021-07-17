﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Base;
using VendingMachine.Services.Interfaces;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
	public class CartItem : ValueObjectBase<CartItem>, IValueObject
	{
		public int Qty { get; }
		public SellItem SellItem { get; }

		public CartItem()
		{
		}

		public CartItem(int qty, SellItem sellItem)
		{
			this.Qty = qty;
			this.SellItem = sellItem;
		}

		public override CartItem Add(CartItem obj)
		{
			if (ReferenceEquals(obj, null))
				throw new NullReferenceException("CartItem can not be null");

			CartItem otherItem = (CartItem)obj;
			if (this.SellItem != otherItem.SellItem)
				throw new NotSameSellItemException();

			return new CartItem(this.Qty + otherItem.Qty, this.SellItem);
		}

		public CartItem Add(int addQty)
		{
			if (addQty < 0)
				throw new Exception("Qty can not be empty");

			return new CartItem(this.Qty + addQty, this.SellItem);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, null))
				throw new NullReferenceException("CartItem can not be null");

			CartItem otherItem = (CartItem)obj;

			if (this.Qty != otherItem.Qty)
				return false;

			if (this.SellItem != otherItem.SellItem)
				return false;

			return true;
		}

		public override int GetHashCode()
		{
			return this.Qty.GetHashCode() ^ this.SellItem.GetHashCode();
		}

		public override CartItem Subtract(CartItem obj)
		{
			if (ReferenceEquals(obj, null))
				throw new NullReferenceException("CartItem can not be null");

			CartItem otherItem = (CartItem)obj;
			if (this.SellItem != otherItem.SellItem)
				throw new NotSameSellItemException();

			int qty = this.Qty - otherItem.Qty;
			if (qty < 0)
				throw new Exception("Qty can not be empty");

			return new CartItem(qty, this.SellItem);
		}

		public override string ToString()
		{
			return $"Sell Item: {this.SellItem.ToString()} Qty: {this.Qty.ToString()}";
		}
	}
}