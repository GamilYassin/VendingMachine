using System.Collections.Generic;

namespace VendingMachine.Services.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        T FindById(int id);
        IEnumerable<T> FindAll();
        int RecordsCount();
        int AddModel(T model, bool commit=false);
        bool Contains(T model);
        int UpdateModel(T model, bool commit = false);
        int DeleteModel(T model, bool commit = false);
        int DeleteModelById(int id, bool commit = false);
        void Commit();
    }
}