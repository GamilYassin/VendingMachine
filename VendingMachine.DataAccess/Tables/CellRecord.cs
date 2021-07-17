namespace VendingMachine.DataAccess.Tables
{
    public class CellRecord
    {
        public int Id { get; set; }
        public int VendingMachineId { get; set; }
        public string CellId { get; set; }
        public int ItemId { get; set; }
        public int ItemQty { get; set; }
    }
}