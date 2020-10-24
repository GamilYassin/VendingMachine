using VendingMachine.Domain.Enums;
using VendingMachine.Domain.BaseClasses;

namespace VendingMachine.Domain.Entities
{
	public class User : EntityBase
	{
		public string UserName { get; set; }
		public string UserPassword { get; set; }
		public UserPrivilege Privilege { get; set; }
	}
}