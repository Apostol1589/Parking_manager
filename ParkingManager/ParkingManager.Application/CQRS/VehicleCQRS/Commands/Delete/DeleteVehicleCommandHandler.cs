using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Contracts;


namespace ParkingManager.Application.CQRS.VehicleCQRS.Commands.Delete
{
    public class DeleteVehicleCommandHandler : ICommandHandler<DeleteVehicleCommand>
    {
        private readonly IVehicleRepository _repository;

        public DeleteVehicleCommandHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteVehicleCommand command, CancellationToken cancellationToken)
        {
            await _repository.Delete(command.Id);
        }
    }

}
