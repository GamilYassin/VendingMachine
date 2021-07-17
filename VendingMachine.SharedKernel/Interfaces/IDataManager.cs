using System.Collections.Generic;

namespace VendingMachine.Services.Interfaces
{
    public interface IDataManager<T> where T : ITable, new()
    {
        #region Properties

        string ConnectionIdentifier { get; }

        #endregion Properties

        #region Methods        

        List<T> FindAll();

        T FindById(int id);

        int Insert(T model);
        int Insert(IEnumerable<T> models);

        int Update(T model);
        int Update(IEnumerable<T> models);

        int Delete(T model);
        int Delete(IEnumerable<T> models);
        #endregion Methods
    }
}