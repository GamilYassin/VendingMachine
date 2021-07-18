using System;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Services.Utils
{
    public class Money
    {
        #region Fields

        public static string DefaultCurrency = "USD";

        public static Money Empty = new Money(0m, DefaultCurrency);

        #endregion Fields

        #region Constructors

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money() : this(0m, DefaultCurrency)
        {
        }

        #endregion Constructors

        #region Properties

        public decimal Amount { get; }
        public string Currency { get; }

        #endregion Properties

        #region Methods

        public static Money operator *(Money money1, decimal val)
        {
            if (money1 is null)
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

        public static Money MoneyFactory(decimal amount)
        {
            return new Money(amount, DefaultCurrency);
        }

        public static Money MoneyFactory(string moneyField)
        {
            string[] values = moneyField.Split(' ');
            if (values.Length != 2)
            {
                return Money.Empty;
            }
            decimal.TryParse(values[0], out decimal amount);
            string currency = values[1];

            return new Money(amount, currency);
        }

        public Money ConvertToCurrency(decimal rate, string newCurrency)
        {
            if (string.Compare(Currency, newCurrency, true) == 0)
                return new Money(Amount, Currency);

            if (rate < 0)
                throw new NegativeMoneyAmountException();

            return new Money(Amount * rate, newCurrency);
        }

        public override bool Equals(object obj)
        {
            return (this == (Money)obj);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() ^ Currency.GetHashCode();
        }

        public override string ToString()
        {
            return Amount.ToString("N2") + $" {Currency}";
        }

        public Money FromString(string moneyField)
        {
            return MoneyFactory(moneyField);
        }

        public Money Add(Money obj)
        {
            return (this + obj);
        }

        public Money Subtract(Money obj)
        {
            return (this - obj);
        }

        public string MoneyField()
        {
            return $"{Amount} {Currency}";
        }

        #endregion Methods
    }
}