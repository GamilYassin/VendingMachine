using System;
using System.Text;

namespace VendingMachine.Services.Utils
{
    public class Balance
    {
        #region Fields

        public static Balance Empty = new Balance(0, 0, 0, 0, 0, 0, 0, 0);
        public static Balance Cent = new Balance(1, 0, 0, 0, 0, 0, 0, 0);
        public static Balance Nickel = new Balance(0, 1, 0, 0, 0, 0, 0, 0);
        public static Balance Dime = new Balance(0, 0, 1, 0, 0, 0, 0, 0);
        public static Balance Quarter = new Balance(0, 0, 0, 1, 0, 0, 0, 0);
        public static Balance Dollar = new Balance(0, 0, 0, 0, 1, 0, 0, 0);
        public static Balance FiveDollar = new Balance(0, 0, 0, 0, 0, 1, 0, 0);
        public static Balance TenDollar = new Balance(0, 0, 0, 0, 0, 0, 1, 0);
        public static Balance TwentyDollar = new Balance(0, 0, 0, 0, 0, 0, 0, 1);

        #endregion Fields

        #region Constructors

        public Balance(int centcount, int nickelcount,
                        int dimecount, int quartercount,
                        int dollarcount, int fivedollarcount,
                        int tendollarcount, int twentydollarcount)
        {
            CentCount = centcount;
            NickelCount = nickelcount;
            DimeCount = dimecount;
            QuarterCount = quartercount;
            DollarCount = dollarcount;
            FiveDollarCount = fivedollarcount;
            TenDollarCount = tendollarcount;
            TwentyDollarCount = twentydollarcount;
        }

        public Balance(): this(0,0,0,0,0,0,0,0)
        {

        }
        #endregion Constructors

        #region Properties

        public int CentCount { get; set; }
        public int NickelCount { get; set; }
        public int DimeCount { get; set; }
        public int QuarterCount { get; set; }
        public int DollarCount { get; set; }
        public int FiveDollarCount { get; set; }
        public int TenDollarCount { get; set; }
        public int TwentyDollarCount { get; set; }

        private static char delimiter = '|';

        #endregion Properties

        #region Methods

        public static Balance operator +(Balance balance1, Balance balance2)
        {
            if (ReferenceEquals(balance1, null) || ReferenceEquals(balance2, null))
                throw new NullReferenceException("One or 2 of balance values are null");

            return new Balance(balance1.CentCount + balance2.CentCount,
                                balance1.NickelCount + balance2.NickelCount,
                                balance1.DimeCount + balance2.DimeCount,
                                balance1.QuarterCount + balance2.QuarterCount,
                                balance1.DollarCount + balance2.DollarCount,
                                balance1.FiveDollarCount + balance2.FiveDollarCount,
                                balance1.TenDollarCount + balance2.TenDollarCount,
                                balance1.TwentyDollarCount + balance2.TwentyDollarCount);
        }

        public static Balance operator -(Balance balance1, Balance balance2)
        {
            if (ReferenceEquals(balance1, null) || ReferenceEquals(balance2, null))
                throw new NullReferenceException("One or 2 of balance values are null");

            if (balance1.CalculateAmount() < balance2.CalculateAmount())
                throw new NegativeMoneyAmountException();

            return new Balance(balance1.CentCount - balance2.CentCount,
                                balance1.NickelCount - balance2.NickelCount,
                                balance1.DimeCount - balance2.DimeCount,
                                balance1.QuarterCount - balance2.QuarterCount,
                                balance1.DollarCount - balance2.DollarCount,
                                balance1.FiveDollarCount - balance2.FiveDollarCount,
                                balance1.TenDollarCount - balance2.TenDollarCount,
                                balance1.TwentyDollarCount - balance2.TwentyDollarCount);
        }

        public static Balance operator *(Balance balance1, Balance balance2)
        {
            if (ReferenceEquals(balance1, null) || ReferenceEquals(balance2, null))
                throw new NullReferenceException("One or 2 of balance values are null");

            return new Balance(balance1.CentCount * balance2.CentCount,
                                balance1.NickelCount * balance2.NickelCount,
                                balance1.DimeCount * balance2.DimeCount,
                                balance1.QuarterCount * balance2.QuarterCount,
                                balance1.DollarCount * balance2.DollarCount,
                                balance1.FiveDollarCount * balance2.FiveDollarCount,
                                balance1.TenDollarCount * balance2.TenDollarCount,
                                balance1.TwentyDollarCount * balance2.TwentyDollarCount);
        }

        public Money CalculateAmount()
        {
            return new Money(CentCount * 0.01m + NickelCount * 0.05m
                            + DimeCount * 0.1m + QuarterCount * 0.25m
                            + DollarCount * 1m + FiveDollarCount * 5m
                            + TenDollarCount * 10m + TwentyDollarCount * 20m, Money.DefaultCurrency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new NullReferenceException();

            return (this == (Balance)obj);
        }

        public override int GetHashCode()
        {
            return CalculateAmount().GetHashCode();
        }

        public override string ToString()
        {
            return $"Balance Amount: {CalculateAmount()}";
        }

        public Balance Add(Balance obj)
        {
            return (this + obj);
        }

        public Balance Subtract(Balance obj)
        {
            return (this - obj);
        }

        public string Encode()
        {
            StringBuilder result = new StringBuilder();
            result.Append(CentCount);
            result.Append(delimiter);
            result.Append(NickelCount);
            result.Append(delimiter);
            result.Append(DimeCount);
            result.Append(delimiter);
            result.Append(QuarterCount);
            result.Append(delimiter);
            result.Append(DollarCount);
            result.Append(delimiter);
            result.Append(FiveDollarCount);
            result.Append(delimiter);
            result.Append(TenDollarCount);
            result.Append(delimiter);
            result.Append(TwentyDollarCount);

            return result.ToString();
        }

        public Balance Decode(string balanceEncode)
        {
            Balance balanceObj = Balance.Empty;
            string[] strValues = balanceEncode.Split(delimiter);

            if (strValues.Length == 8)
            {
                int tmp = 0;
                Int32.TryParse(strValues[0], out tmp);
                balanceObj.CentCount = tmp;
                Int32.TryParse(strValues[1], out tmp);
                balanceObj.NickelCount = tmp;
                Int32.TryParse(strValues[2], out tmp);
                balanceObj.DimeCount = tmp;
                Int32.TryParse(strValues[3], out tmp);
                balanceObj.QuarterCount = tmp;
                Int32.TryParse(strValues[4], out tmp);
                balanceObj.DollarCount = tmp;
                Int32.TryParse(strValues[5], out tmp);
                balanceObj.FiveDollarCount = tmp;
                Int32.TryParse(strValues[6], out tmp);
                balanceObj.TenDollarCount = tmp;
                Int32.TryParse(strValues[7], out tmp);
                balanceObj.TwentyDollarCount = tmp;
            }
            return balanceObj;
        }

        #endregion Methods
    }
}