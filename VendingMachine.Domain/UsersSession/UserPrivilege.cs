

using VendingMachine.Services.EnumerationBase;

namespace VendingMachine.Domain.Models
{

    public class UserPrivilegeEnum: Enumeration
    {
        public UserPrivilegeEnum(int value, string displayName): base(value, displayName)
        {

        }

        public static UserPrivilegeEnum Maintenance = new UserPrivilegeEnum(1, "Maintenance");
        public static UserPrivilegeEnum Operator = new UserPrivilegeEnum(2, "Operator");
        public static UserPrivilegeEnum Customer = new UserPrivilegeEnum(3, "Customer");
    }

}