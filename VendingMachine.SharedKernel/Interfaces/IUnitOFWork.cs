using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Services.Interfaces
{
   public interface IUnitOFWork<T> where T : ITable
    {
        void RegisterNew(T model);
        void RegisterChanged(T model);
        void RegisterDeleted(T model);
        void Commit();
    }
}
