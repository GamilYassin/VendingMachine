using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Tables
{
    public class CellTableRecord: ITable
    {
        public int Id { get; set; }
        public int VendingMachineId { get; set; }
        public string CellId { get; set; }
        public int ItemId { get; set; }
        public int ItemQty { get; set; }

        public CellTableRecord(): this(0,0, string.Empty,0,0)
        {

        }

        public CellTableRecord(int id,int vmId, string cellId, int itemId, int itemQty)
        {
            Id=id;
            VendingMachineId=vmId;
            CellId=cellId;
            ItemId=itemId;
            ItemQty=itemQty;
        }


    }
}