using VendingMachine.Services.EnumerationBase;

namespace VendingMachine.Domain.Enums
{
    public class CurrencyEnum : Enumeration
    {
        public CurrencyEnum(int value, string displayName) : base(value, displayName)
        {

        }

        public static CurrencyEnum USD = new CurrencyEnum(1, "USD");
        public static CurrencyEnum SAR = new CurrencyEnum(2, "SAR");
        public static CurrencyEnum EURO = new CurrencyEnum(2, "EURO");
    }
}