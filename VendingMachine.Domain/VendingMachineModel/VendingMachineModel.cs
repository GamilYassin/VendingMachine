using System.Collections.Generic;
using VendingMachine.Domain.Base;
using VendingMachine.Services.Interfaces;
using VendingMachine.Services.Utils;

namespace VendingMachine.Domain.Models
{
    public class VendingMachineModel : EntityBase, IAggregateRoot
    {
        #region Properties

        public LocationModel VMLocation { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public MaintenanceSchedule VMMaintenanceSchedule { get; set; }
        public Money GrandBalanceAmount { get; set; }
        public Balance InsideBalance { get; set; }
        public Date StartDate { get; set; }
        public IList<CellModel> Cells { get; set; }
        public VendingMachineStateEnum State { get; set; }

        public VendingMachineModel()
        {
            VMLocation = new LocationModel();
            VMMaintenanceSchedule = new MaintenanceSchedule();
            GrandBalanceAmount = Money.Empty;
            InsideBalance = Balance.Empty;
            Cells= new List<CellModel>();
            State = VendingMachineStateEnum.Starting;
        }

        public override string ToString()
        {
            return $"{Manufacturer}, {Model}, {VMLocation}";
        }

        #endregion Properties
    }
}