using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Entities;
using ParkingManager.Infrastructure.Repositories.VehicleRepo;

namespace ParkingManager.Application.CQRS.VehicleCQRS.Commands.Update
{
    public class UpdateVehicleCommandHandler : ICommandHandler<UpdateVehicleCommand>
    {
        private readonly IVehicleRepository _repository;

        public UpdateVehicleCommandHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                Id = command.Id,
                LicencePlate = command.LicencePlate,
                Mark = command.Mark,
                Model = command.Model,
                Color = command.Color
            };
            await _repository.Update(vehicle);
        }
    }

}
