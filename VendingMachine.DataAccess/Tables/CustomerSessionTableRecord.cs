using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Tables
{
    public class CustomerSessionTableRecord : ITable
    {
        public int Id { get; set; }
        public int VendingMachineId { get; set; }
        public string BalanceText { get; set; }
        public string Status { get; set; }
    }
}
