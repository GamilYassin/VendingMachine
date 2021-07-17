using System;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.Models
{
    public class CartItem
    {
        public int Qty { get; set; }
        public SellItemModel SellItem { get; set; }

        public CartItem()
        {
        }

        public CartItem(int qty, SellItemModel sellItem)
        {
            Qty = qty;
            SellItem = sellItem;
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


        public override string ToString()
        {
            return $"Sell Item: {SellItem.ToString()} Qty: {Qty.ToString()}";
        }
    }
}