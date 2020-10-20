using VendingMachine.Domain.Enums;

namespace VendingMachine.Domain.Entities
{
    public class User: Entity
    {
        public string UserName{get; set;}
        public string UserPassword{get; set;}
        public UserPrivilege Privilege{get; set;}
    }
}