using System.Collections.Generic;

namespace VendingMachine.Services.Interfaces
{
    public interface IUnitOFWork<T> where T : ITable
    {
        //void RegisterNew(T model);
        //void RegisterChanged(T model);
        //void RegisterDeleted(T model);
        bool IsCommitted();
        int Commit();

        T FindById(int id);
        IEnumerable<T> FindAll();
        int RecordsCount();
        int AddModel(T model, bool commit = false);
        bool Contains(T model);
        int UpdateModel(T model, bool commit = false);
        int DeleteModel(T model, bool commit = false);
        int DeleteModelById(int id, bool commit = false);
    }
}
