using System.Collections.Generic;

namespace VendingMachine.Services.Interfaces
{
    public interface IDataManager<T> where T : IEntity, new()
    {
        #region Properties

        string ConnectionIdentifier { get; }

        #endregion Properties

        #region Methods

        int Delete(T model);

        List<T> FindAll(string tableName);

        T FindById(int id);

        int Insert(T model);

        int Update(T model);

        #endregion Methods
    }
}