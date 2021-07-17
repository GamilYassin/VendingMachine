using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Services.Interfaces
{
	public interface IRepository<T> where T : IEntity
	{
		T FindbyId(int id);

		List<T> GetAll();

		void SaveChanges();
	}
}