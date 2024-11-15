using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Entities;
using ParkingManager.Infrastructure.Repositories.VehicleRepo;

namespace ParkingManager.Application.CQRS.VehicleCQRS.Commands.Create
{
    public class CreateVehicleCommandHandler : ICommandHandler<CreateVehicleCommand, int>
    {
        private readonly IVehicleRepository _repository;

        public CreateVehicleCommandHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateVehicleCommand command, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                LicencePlate = command.LicencePlate,
                Mark = command.Mark,
                Model = command.Model,
                Color = command.Color
            };
            await _repository.Create(vehicle);
            return vehicle.Id;
        }
    }
}
