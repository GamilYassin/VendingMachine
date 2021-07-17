using System;
using VendingMachine.Domain.ValueObjects;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.Models
{
    public class Cell : IValueObject
    {
        public string CellId { get; }
        public SellItemModel SellItem { get; }
        public int SellItemQty { get; }
        public int VendingMachineId { get; set; }

        public Cell(int vmId, string cellId, SellItemModel sellItem, int itemQty)
        {
            VendingMachineId = vmId;
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