using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Tables
{
    public class LocationTableRecord : ITable
    {
        public int Id { get; set; }
        public int VendingMachineId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }

        public LocationTableRecord(int id, int vmId, string street, string city, string landmark)
        {
            Id = id;
            VendingMachineId = vmId;
            City = city;
            Landmark = landmark;
            Street = street;
        }

        public LocationTableRecord() : this(0, 0, string.Empty, string.Empty, string.Empty)
        {

        }
    }
}