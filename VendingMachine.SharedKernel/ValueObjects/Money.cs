using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.SharedKernel.Enums;
using VendingMachine.SharedKernel.Exceptions;
using VendingMachine.SharedKernel.Interfaces;

namespace VendingMachine.SharedKernel.ValueObjects
{
	public class Money : ValueObjectBase<Money>, IValueObject
	{
		#region Constructors

		public Money(Decimal amount, Currency currency)
		{
			this.Amount = amount;
			this.Currency = currency;
		}

		public Money() : this(0m, Currency.US)
		{
		}

		#endregion Constructors

		#region Properties

		public Decimal Amount { get; }
		public Currency Currency { get; }

		#endregion Properties

		#region Methods

		public static Money operator +(Money money1, Money money2)
		{
			if (money1.Currency != money2.Currency)
				throw new NotSameCurrencyException();

			if (ReferenceEquals(money1, null) || ReferenceEquals(money2, null))
				throw new NullReferenceException("One or both money values are null referenced");

			return new Money(money1.Amount + money2.Amount, money1.Currency);
		}

		public static Money operator -(Money money1, Money money2)
		{
			if (money1.Currency != money2.Currency)
				throw new NotSameCurrencyException();

			if (ReferenceEquals(money1, null) || ReferenceEquals(money2, null))
				throw new NullReferenceException("One or both money values are null referenced");

			if (money2.Amount > money1.Amount)
				throw new NegativeMoneyAmountException();

			return new Money(money1.Amount - money2.Amount, money1.Currency);
		}

		public static bool operator <(Money money1, Money money2)
		{
			if (money1.Currency != money2.Currency)
				throw new NotSameCurrencyException();

			if (ReferenceEquals(money1, null) || ReferenceEquals(money2, null))
				throw new NullReferenceException("One or both money values are null referenced");

			if (money2.Amount < money1.Amount)
				return true;

			return false;
		}

		public static bool operator >(Money money1, Money money2)
		{
			if (money1.Currency != money2.Currency)
				throw new NotSameCurrencyException();

			if (ReferenceEquals(money1, null) || ReferenceEquals(money2, null))
				throw new NullReferenceException("One or both money values are null referenced");

			if (money2.Amount > money1.Amount)
				return true;

			return false;
		}

		public static bool operator ==(Money money1, Money money2)
		{
			if (money1.Currency != money2.Currency)
				throw new NotSameCurrencyException();

			if (ReferenceEquals(money1, null) || ReferenceEquals(money2, null))
				throw new NullReferenceException("One or both money values are null referenced");

			if (money2.Amount == money1.Amount)
				return true;

			return false;
		}

		public static bool operator !=(Money money1, Money money2)
		{
			return !(money1 == money2);
		}

		public static Money MoneyFactory(Decimal amount)
		{
			return new Money(amount, Currency.US);
		}

		public Money ConvertToCurrency(decimal rate, Currency currency)
		{
			if (this.Currency == currency)
				return new Money(this.Amount, this.Currency);

			if (rate < 0)
				throw new NegativeMoneyAmountException();

			return new Money(this.Amount * rate, currency);
		}

		public override bool Equals(object obj)
		{
			return (this == (Money)obj);
		}

		public override int GetHashCode()
		{
			return this.Amount.GetHashCode() ^ this.Currency.GetHashCode();
		}

		public override string ToString()
		{
			return this.Amount.ToString("N2") + $" {this.Currency.ToString()}";
		}

		public override Money Add(Money obj)
		{
			return (this + obj);
		}

		public override Money Subtract(Money obj)
		{
			return (this - obj);
		}

		#endregion Methods
	}
}