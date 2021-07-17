using System.Collections.Generic;
using VendingMachine.Domain.Base;
using VendingMachine.Services.Interfaces;
using VendingMachine.Domain.Enums;
using VendingMachine.Domain.ValueObjects;

namespace VendingMachine.Domain.Entities
{
	public class VendingMachine : EntityBase, IAggregateRoot
	{
		#region Properties

		public Location VMLocation { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public MaintenanceSchedule VMMaintenanceSchedule { get; set; }
		public Money GrandBalance { get; set; }
		public Money CustomerBalance { get; set; }
		public Balance InsideBalance { get; set; }
		public Date StartDate { get; set; }
		public IList<Cell> Cells { get; set; }
		public VMState State { get; set; }

		#endregion Properties
	}
}