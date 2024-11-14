using ParkingManager.DataAccess.Repositories.VehicleRepo;

namespace ParkingManager.BusinessLogic.Commands.VehicleCommands
{
    public class RemoveVehicleCommand : ICommand
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly int _vehicleId;

        public RemoveVehicleCommand(IVehicleRepository vehicleRepository, int vehicleId)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleId = vehicleId;
        }

        public async Task ExecuteAsync()
        {
            await _vehicleRepository.Delete(_vehicleId);
        }
    }
}
