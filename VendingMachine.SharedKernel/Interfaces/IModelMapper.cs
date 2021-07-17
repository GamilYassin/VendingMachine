namespace VendingMachine.Services.Interfaces
{
    public interface IModelMapper<SourceT, DestinationT>
    {
        #region Methods

        DestinationT MapForward(SourceT domainModel);

        SourceT MapBackward(DestinationT databaseModel);

        #endregion Methods
    }
}