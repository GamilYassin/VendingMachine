using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.SharedKernel.Interfaces;

namespace VendingMachine.Domain.BaseClasses
{
	public abstract class Entity : IEntity
	{
		#region Constructors

		public Entity()
		{
		}

		public Entity(int id)
		{
			this.Id = id;
		}

		#endregion Constructors

		#region Properties

		public int Id { get; set; }

		#endregion Properties
	}
}