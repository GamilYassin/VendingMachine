using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.SharedKernel.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Presentation.Repositories
{
	public class UsersRepository : IRepository<User>
	{
		public User FindbyId(int id)
		{
			throw new NotImplementedException();
		}

		public List<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}
	}
}