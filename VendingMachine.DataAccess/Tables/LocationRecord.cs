namespace VendingMachine.DataAccess.Tables
{
    public class LocationRecord
    {
        public int Id { get; set; }
        public int VendingMachineId { get; set; }
        public string Stret { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
    }
}