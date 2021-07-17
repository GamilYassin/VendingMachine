using System;

namespace VendingMachine.Domain.Models
{
    public class CellModel
    {
        public string CellId { get; }
        public SellItemModel SellItem { get; }
        public int SellItemQty { get; }

        public CellModel(string cellId, SellItemModel sellItem, int itemQty)
        {
            CellId = cellId;
            SellItem = sellItem;
            SellItemQty = itemQty;
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new NullReferenceException();

            CellModel otherCell = (CellModel)obj;
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