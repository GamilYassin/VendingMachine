namespace VendingMachine.Services.Interfaces
{
    public interface IModelMapper<TDomain, TTable>
    {
        #region Methods

        TTable MapFromDomain(TDomain domainModel);

        void MapFromTable(ref TDomain domainModel, TTable databaseModel);

        #endregion Methods
    }
}