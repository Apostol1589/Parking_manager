using Microsoft.Extensions.Logging;
using ParkingManager.BusinessLogic.Builder;
using ParkingManager.DataAccess.Repositories.VehicleRepo;

namespace ParkingManager.BusinessLogic.Prototype
{
    public class VehicleModelService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleModelService(IVehicleRepository vehicleRepository,
            ILoggerFactory loggerFactory)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task Create(VehicleModel vehicleModel)
        {
            var clonedVehicleModel = (VehicleModel)vehicleModel.Clone();

            var vehicle = new VehicleBuilder()
                .SetLicencePlate(clonedVehicleModel.LicencePlate)
                .SetMark(clonedVehicleModel.Mark)
                .SetModel(clonedVehicleModel.Model)
                .SetColor(clonedVehicleModel.Color)
                .Build();

            await _vehicleRepository.Update(vehicle);
        }

        public async Task Update(VehicleModel vehicleModel)
        {
            var clonedVehicleModel = (VehicleModel)vehicleModel.Clone();

            var vehicle = new VehicleBuilder()
                .SetLicencePlate(clonedVehicleModel.LicencePlate)
                .SetMark(clonedVehicleModel.Mark)
                .SetModel(clonedVehicleModel.Model)
                .SetColor(clonedVehicleModel.Color)
                .Build();

            await _vehicleRepository.Create(vehicle);
        }
    }
}
