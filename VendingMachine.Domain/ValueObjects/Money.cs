﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Enums;
using VendingMachine.Domain.BaseClasses;
using VendingMachine.Domain.Exceptions;
using VendingMachine.SharedKernel.Interfaces;

namespace VendingMachine.Domain.ValueObjects
{
	public class Money : ValueObjectBase<Money>, IValueObject
	{
		public static string DefaultCurrency = "USD";

		public static Money Empty = new Money(0m, DefaultCurrency);

		#region Constructors

		public Money(Decimal amount, string currency)
		{
			this.Amount = amount;
			this.Currency = currency;
		}

		public Money() : this(0m, DefaultCurrency)
		{
		}

		#endregion Constructors

		#region Properties

		public Decimal Amount { get; }
		public string Currency { get; }

		#endregion Properties

		#region Methods

		public static Money operator *(Money money1, Decimal val)
		{
			if (ReferenceEquals(money1, null))
				throw new NullReferenceException("Money values are null referenced");

			return new Money(money1.Amount * val, money1.Currency);
		}

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
			return new Money(amount, DefaultCurrency);
		}

		public static Money MoneyFactory(string moneyField)
		{
			string[] values = moneyField.Split(' ');

			return new Money(Decimal.Parse(values[0]), values[1]);
		}

		public Money ConvertToCurrency(decimal rate, string newCurrency)
		{
			if (string.Compare(this.Currency, newCurrency, true) == 0)
				return new Money(this.Amount, this.Currency);

			if (rate < 0)
				throw new NegativeMoneyAmountException();

			return new Money(this.Amount * rate, newCurrency);
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

		public String AmoneyField()
		{
			return $"{this.Amount.ToString()} {this.Currency}";
		}

		#endregion Methods
	}
}