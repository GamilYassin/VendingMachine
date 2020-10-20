using VendingMachine.Domain.Enums;

namespace VendingMachine.Domain.Entities
{
    public class CustomerSession: Entity
    {
        public Balance CustomerBalance{get; set;}
        public Cart CustomerCart{get; set;}
        public CustomerSessionStatus Status{get; set;}
    }
}