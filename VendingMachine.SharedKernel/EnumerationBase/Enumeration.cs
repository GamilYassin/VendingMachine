using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VendingMachine.Services.EnumerationBase
{
    public class Enumeration : IComparable
    {
        private readonly string _displayName;
        private readonly int _value;

        public Enumeration(int value, string name)
        {
            (_value, _displayName) = (value, name);
        }

        public string DisplayName => _displayName;
        public int Value => _value;

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            T matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                string message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            return Math.Abs(firstValue.Value - secondValue.Value);
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        {
            T matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        public static T FromValue<T>(int value) where T : Enumeration, new()
        {
            return Parse<T, int>(value, "value", item => item.Value == value);
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly).Select(f => f.GetValue(null)).Cast<T>();
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration)other).Value);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }

            bool typeMatches = GetType().Equals(obj.GetType());
            bool valueMatches = _value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public string GetName()
        {
            return _displayName;
        }

        public int GetValue()
        {
            return _value;
        }

        public override string ToString()
        {
            return _displayName;
        }
    }
}
