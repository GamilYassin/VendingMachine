using System;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.ValueObjects
{
    public class CartItem
    {
        public int Qty { get; }
        public SellItemModel SellItem { get; }

        public CartItem()
        {
        }

        public CartItem(int qty, SellItemModel sellItem)
        {
            Qty = qty;
            SellItem = sellItem;
        }

        public CartItem Add(CartItem obj)
        {
            if (ReferenceEquals(obj, null))
                throw new NullReferenceException("CartItem can not be null");

            CartItem otherItem = obj;
            if (SellItem != otherItem.SellItem)
                throw new NotSameSellItemException();

            return new CartItem(Qty + otherItem.Qty, SellItem);
        }

        public CartItem Add(int addQty)
        {
            if (addQty < 0)
                throw new Exception("Qty can not be empty");

            return new CartItem(Qty + addQty, SellItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new NullReferenceException("CartItem can not be null");

            CartItem otherItem = (CartItem)obj;

            if (Qty != otherItem.Qty)
                return false;

            if (SellItem != otherItem.SellItem)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Qty.GetHashCode() ^ SellItem.GetHashCode();
        }

        public CartItem Subtract(CartItem obj)
        {
            if (ReferenceEquals(obj, null))
                throw new NullReferenceException("CartItem can not be null");

            CartItem otherItem = obj;
            if (SellItem != otherItem.SellItem)
                throw new NotSameSellItemException();

            int qty = Qty - otherItem.Qty;
            if (qty < 0)
                throw new Exception("Qty can not be empty");

            return new CartItem(qty, SellItem);
        }

        public override string ToString()
        {
            return $"Sell Item: {SellItem.ToString()} Qty: {Qty.ToString()}";
        }
    }
}