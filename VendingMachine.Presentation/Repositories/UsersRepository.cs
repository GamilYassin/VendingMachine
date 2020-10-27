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
using VendingMachine.Domain.Enums;
using System.Security.Cryptography.X509Certificates;

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
				var userRecord = dbContext.UserRecords.Select(x => x).Where(x => x.Id == id).First();

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
			using (var dbContext = VendingMachineContext.InstanceFactory())
			{
				dbContext.SaveChanges();
			}
		}

		public UserPrivilege GetUserPrivilege(string userName, string userPass)
		{
			UserPrivilege privilege;

			using (var dbContext = VendingMachineContext.InstanceFactory())
			{
				var userPrivlege = dbContext.UserRecords.Where(x => string.Compare(x.UserName, userName, true) == 0 &&
																	string.Compare(x.UserPassword, userPass, true) == 0)
														.Select(x => x.Privilege).First();
				Enum.TryParse(userPrivlege, out privilege);
			}

			return privilege;
		}

		public void InsertUser(User user)
		{
			UsersModelMapper map = new UsersModelMapper();
			InsertUser(map.MapForward(user));
		}

		public void InsertUser(UserRecord user)
		{
			using (var dbContext = VendingMachineContext.InstanceFactory())
			{
				dbContext.UserRecords.Add(user);
				dbContext.SaveChanges();
			}
		}

		public void UpdateUser(UserRecord user)
		{
			using (var dbContext = VendingMachineContext.InstanceFactory())
			{
				var userRecord = dbContext.UserRecords.Select(x => x).Where(x => x.Id == user.Id).First();

				user.CopyTo(ref userRecord);
				dbContext.SaveChanges();
			}
		}

		public void UpdateUser(User user)
		{
			UsersModelMapper map = new UsersModelMapper();
			UpdateUser(map.MapForward(user));
		}

		public void DeleteUser(int id)
		{
			using (var dbContext = VendingMachineContext.InstanceFactory())
			{
				var userRecord = dbContext.UserRecords.Select(x => x).Where(x => x.Id == id).First();

				dbContext.UserRecords.Remove(userRecord);
				dbContext.SaveChanges();
			}
		}

		public void DeleteUser(User user)
		{
			DeleteUser(user.Id);
		}

		#endregion Methods
	}
}