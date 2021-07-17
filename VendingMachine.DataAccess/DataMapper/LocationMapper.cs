using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Models;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataMapper
{
    public class LocationMapper : IModelMapper<VendingMachineModel, LocationTableRecord>
    {
        public LocationTableRecord MapFromDomain(VendingMachineModel domainModel)
        {
            return new LocationTableRecord()
            {
                City = domainModel.VMLocation.City,
                Street = domainModel.VMLocation.Street,
                Landmark = domainModel.VMLocation.LandMark,
                VendingMachineId = domainModel.Id
            };
        }

        public void MapFromTable(ref VendingMachineModel domainModel, LocationTableRecord databaseModel)
        {
            if (domainModel == null)
            {
                return;
            }

            domainModel.VMLocation.City = databaseModel.City;
            domainModel.VMLocation.Street = databaseModel.Street;
            domainModel.VMLocation.LandMark = databaseModel.Landmark;
        }
    }
}
