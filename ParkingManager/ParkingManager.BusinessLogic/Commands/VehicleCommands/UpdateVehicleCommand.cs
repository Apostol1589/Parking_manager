using ParkingManager.DataAccess.Entities;
using ParkingManager.DataAccess.Repositories.VehicleRepo;

namespace ParkingManager.BusinessLogic.Commands.VehicleCommands
{
    public class UpdateVehicleCommand : ICommand
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly Vehicle _vehicle;

        public UpdateVehicleCommand(IVehicleRepository vehicleRepository, Vehicle vehicle)
        {
            _vehicleRepository = vehicleRepository;
            _vehicle = vehicle;
        }

        public async Task ExecuteAsync()
        {
            await _vehicleRepository.Create(_vehicle);
        }
    }
}
