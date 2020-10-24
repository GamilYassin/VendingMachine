using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.SharedKernel.Interfaces;
using VendingMachine.Domain.Entities;
using VendingMachine.Presentation.Context;
using VendingMachine.Presentation.DataBaseModels;
using VendingMachine.Presentation.ModelMappers;

namespace VendingMachine.Presentation.Repositories
{
	public class UsersRepository : IRepository<User>
	{
		#region Methods

		public User FindbyId(int id)
		{
			UsersModelMapper map = new UsersModelMapper();

			using (var dbContext = VendingMachineContext.InstanceFactory())
			{
				var userRecord = dbContext.UserRecords.Select(x => x).Where(x => x.Id == id).FirstOrDefault();

				return map.MapBackward(userRecord);
			}
		}

		public List<User> GetAll()
		{
			List<User> users = new List<User>();
			UsersModelMapper map = new UsersModelMapper();

			using (var dbContext = VendingMachineContext.InstanceFactory())
			{
				var userRecords = dbContext.UserRecords.Select(x => x).ToList();

				foreach (var item in userRecords)
				{
					users.Add(map.MapBackward(item));
				}
			}

			return users;
		}

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}

		#endregion Methods
	}
}