using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.SharedKernel.Interfaces;

namespace VendingMachine.Domain.BaseClasses
{
	public abstract class EntityBase : IEntity
	{
		#region Constructors

		public EntityBase()
		{
		}

		public EntityBase(int id)
		{
			this.Id = id;
		}

		#endregion Constructors

		#region Properties

		public int Id { get; set; }

		#endregion Properties
	}
}