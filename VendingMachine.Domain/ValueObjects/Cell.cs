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
            CellId = CellId;
            SellItem = sellItem;
            SellItemQty = itemQty;
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new NullReferenceException();

            Cell otherCell = (Cell)obj;
            if (CellId != otherCell.CellId)
                return false;
            if (SellItem != otherCell.SellItem)
                return false;
            if (SellItemQty != otherCell.SellItemQty)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return CellId.GetHashCode() * SellItem.GetHashCode() * SellItemQty.GetHashCode();
        }


        public override string ToString()
        {
            return $"Cell Id: {CellId} Sell Item: {SellItem.ToString()} Qty: {SellItemQty}";
        }
    }
}