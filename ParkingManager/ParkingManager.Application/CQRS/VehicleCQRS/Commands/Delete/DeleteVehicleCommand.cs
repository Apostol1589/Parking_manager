using ParkingManager.Application.CQRS.Core;

namespace ParkingManager.Application.CQRS.VehicleCQRS.Commands.Delete
{
    public class DeleteVehicleCommand : ICommand
    {
        public int Id { get; }

        public DeleteVehicleCommand(int id)
        {
            Id = id;
        }
    }
}
