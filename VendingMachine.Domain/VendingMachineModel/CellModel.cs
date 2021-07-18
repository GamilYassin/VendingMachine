using System;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.Models
{
    public class CellModel: IEntity
    {
        public string CellId { get; set; }
        public SellItemModel SellItem { get; set; }
        public int SellItemQty { get; set; }
        public int VendingMachineId { get; set; }
        public int Id { get; set; }

        public CellModel(int vmId, string cellId, SellItemModel sellItem, int itemQty)
        {
            VendingMachineId = vmId;
            CellId = cellId;
            if (sellItem == null)
            {
                SellItem = new SellItemModel();
            }
            else
            {
                SellItem = sellItem;
            }
            SellItemQty = itemQty;
        }

        public CellModel() : this(0, string.Empty, null, 0)
        {

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