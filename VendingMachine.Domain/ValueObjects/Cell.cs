using System;
using VendingMachine.Domain.ValueObjects;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.Entities
{
    public class Cell : IValueObject
    {
        public string CellId { get; }
        public SellItem SellItem { get; }
        public int SellItemQty { get; }

        public Cell(string cellId, SellItem sellItem, int itemQty)
        {
            this.CellId = CellId;
            this.SellItem = sellItem;
            this.SellItemQty = itemQty;
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new NullReferenceException();

            Cell otherCell = (Cell)obj;
            if (this.CellId != otherCell.CellId)
                return false;
            if (this.SellItem != otherCell.SellItem)
                return false;
            if (this.SellItemQty != otherCell.SellItemQty)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return this.CellId.GetHashCode() * this.SellItem.GetHashCode() * this.SellItemQty.GetHashCode();
        }


        public override string ToString()
        {
            return $"Cell Id: {this.CellId} Sell Item: {this.SellItem.ToString()} Qty: {this.SellItemQty}";
        }
    }
}