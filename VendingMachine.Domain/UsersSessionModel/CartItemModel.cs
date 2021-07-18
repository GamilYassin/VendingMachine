using System;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.Models
{
    public class CartItemModel: IEntity
    {
        public int Qty { get; set; }
        public SellItemModel SellItem { get; set; }
        public int Id { get; set; }
        public int SessionId { get; set; }

        public CartItemModel() : this(0, null)
        {
        }

        public CartItemModel(int qty, SellItemModel sellItem)
        {
            Qty = qty;
            if (sellItem == null)
            {
                SellItem = new SellItemModel();
            }
            else
            {
                SellItem = sellItem;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new NullReferenceException("CartItem can not be null");

            CartItemModel otherItem = (CartItemModel)obj;

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