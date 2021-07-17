using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Enums;
using VendingMachine.Domain.Base;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.ValueObjects
{
	public class Balance :  IValueObject
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

		#endregion Constructors

		#region Properties

		public int CentCount { get; }
		public int NickelCount { get; }
		public int DimeCount { get; }
		public int QuarterCount { get; }
		public int DollarCount { get; }
		public int FiveDollarCount { get; }
		public int TenDollarCount { get; }
		public int TwentyDollarCount { get; }

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

		public  Balance Add(Balance obj)
		{
			return (this + obj);
		}

		public  Balance Subtract(Balance obj)
		{
			return (this - obj);
		}

		#endregion Methods
	}
}