namespace VendingMachine.Services.Interfaces
{
    public interface IModelMapper<TDomain, TTable> where TDomain : IEntity where TTable : ITable
    {
        #region Methods

        TTable MapFromDomain(TDomain domainModel);

        void MapFromTable(ref TDomain domainModel, TTable databaseModel);

        #endregion Methods
    }
}