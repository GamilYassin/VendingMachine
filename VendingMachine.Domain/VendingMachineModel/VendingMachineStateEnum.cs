
using VendingMachine.Services.EnumerationBase;

namespace VendingMachine.Domain.Models
{

    public class VendingMachineStateEnum: Enumeration
    {
        public VendingMachineStateEnum(int value, string displayName): base(value, displayName)
        {

        }

        public static VendingMachineStateEnum Starting = new VendingMachineStateEnum(1,"Starting");
        public static VendingMachineStateEnum Operational = new VendingMachineStateEnum(2, "Operational");
        public static VendingMachineStateEnum OnHold = new VendingMachineStateEnum(3, "OnHold");
        public static VendingMachineStateEnum OnMaintenance = new VendingMachineStateEnum(4, "OnMaintenance");
        public static VendingMachineStateEnum Defect = new VendingMachineStateEnum(5, "Defect");
    }
}