using ParkingManager.DataAccess.Entities;
using ParkingManager.DataAccess.Repositories.VehicleRepo;

namespace ParkingManager.BusinessLogic.Commands.VehicleCommands
{
    public class CreateVehicleCommand : ICommand
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly Vehicle _vehicle;

        public CreateVehicleCommand(IVehicleRepository vehicleRepository, Vehicle vehicle)
        {
            _vehicleRepository = vehicleRepository;
            _vehicle = vehicle;
        }

        public async Task ExecuteAsync()
        {
            await _vehicleRepository.Update(_vehicle);
        }
    }
}
