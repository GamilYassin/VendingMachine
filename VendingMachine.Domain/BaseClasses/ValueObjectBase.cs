using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.SharedKernel.Interfaces;

namespace VendingMachine.Domain.BaseClasses
{
	public abstract class ValueObjectBase<T> where T : IValueObject
	{
		#region Methods

		public abstract override string ToString();

		public abstract override bool Equals(object obj);

		public abstract override int GetHashCode();

		public abstract T Add(T obj);

		public abstract T Subtract(T obj);

		#endregion Methods
	}
}