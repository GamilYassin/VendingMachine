using VendingMachine.Services.EnumerationBase;

namespace VendingMachine.Domain.Models
{

    public class SellItemTypeEnum : Enumeration
    {
        public SellItemTypeEnum(int value, string displayName) : base(value, displayName)
        {

        }

        public static SellItemTypeEnum Food = new SellItemTypeEnum(1, "Food");
        public static SellItemTypeEnum Drink = new SellItemTypeEnum(2, "Drink");
        public static SellItemTypeEnum Snaks = new SellItemTypeEnum(3, "Snaks");
    }
}