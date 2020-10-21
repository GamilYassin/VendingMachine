using VendingMachine.Domain.Enums;
using VendingMachine.Domain.BaseClasses;
using VendingMachine.SharedKernel.ValueObjects;

namespace VendingMachine.Domain.Entities
{
	public class CustomerSession : Entity
	{
		public Balance CustomerBalance { get; set; }
		public Cart CustomerCart { get; set; }
		public CustomerSessionStatus Status { get; set; }
	}
}