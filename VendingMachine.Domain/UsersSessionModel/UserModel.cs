using VendingMachine.Domain.Base;

namespace VendingMachine.Domain.Models
{
    public class UserModel : EntityBase
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public UserPrivilegeEnum Privilege { get; set; }

        public UserModel()
        {
            Privilege = UserPrivilegeEnum.Maintenance;
        }

        public override string ToString()
        {
            return UserName;
        }
    }
}