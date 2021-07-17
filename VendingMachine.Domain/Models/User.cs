using VendingMachine.Domain.Base;
using VendingMachine.Domain.Enums;

namespace VendingMachine.Domain.Models
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public UserPrivilegeEnum Privilege { get; set; }

        public override string ToString()
        {
            return UserName;
        }
    }
}