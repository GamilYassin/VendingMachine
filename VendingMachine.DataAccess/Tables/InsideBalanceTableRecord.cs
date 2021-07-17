using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Tables
{
    public class InsideBalanceTableRecord: ITable
    {
        public int Id { get; set; }
        public int VendingMachineId { get; set; }
        public int CentCount { get; set; }
        public int NickelCount { get; set; }
        public int DimeCount { get; set; }
        public int QuarterCount { get; set; }
        public int DollarCount { get; set; }
        public int FiveDollarCount { get; set; }
        public int TenDollarCount { get; set; }
        public int TwentyDollarCount { get; set; }


        public InsideBalanceTableRecord(int id, int vmId, int centCount, int nickleCount, int dimeCount, int quarterCount, int dollarCount, int fiveDollarCount, int tenDollarCount, int twentyDollarCount)
        {
            Id=id;
            VendingMachineId=vmId;
            CentCount=centCount;
            NickelCount=nickleCount;
            DimeCount=dimeCount;
            QuarterCount=quarterCount;
            DollarCount = dollarCount;
            FiveDollarCount = fiveDollarCount;
            TenDollarCount =tenDollarCount;
            TwentyDollarCount = twentyDollarCount;

        }

        public InsideBalanceTableRecord(): this(0,0,0,0,0,0,0,0,0,0)
        {

        }
    }
}