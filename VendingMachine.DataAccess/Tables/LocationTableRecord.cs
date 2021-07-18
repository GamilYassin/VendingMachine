using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Tables
{
    public class LocationTableRecord : ITable
    {
        public int VendingMachineId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
        public int Id { get; set; }

        public LocationTableRecord(int vmId, string street, string city, string landmark)
        {
            VendingMachineId = vmId;
            City = city;
            Landmark = landmark;
            Street = street;
        }

        public LocationTableRecord() : this(0, string.Empty, string.Empty, string.Empty)
        {

        }
    }
}