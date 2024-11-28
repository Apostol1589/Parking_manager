using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Contracts;


namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Commands.Update
{
    public class UpdateParkingLotCommandHandler : ICommandHandler<UpdateParkingLotCommand>
    {
        private readonly IParkingLotRepository _repository;

        public UpdateParkingLotCommandHandler(IParkingLotRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateParkingLotCommand command, CancellationToken cancellationToken)
        {
            var parkingLot = await _repository.Get(command.Id);
            if (parkingLot == null)
            {
                throw new KeyNotFoundException($"Parking lot with ID {command.Id} not found.");
            }

            parkingLot.Name = command.Name;
            parkingLot.Location = command.Location;

            await _repository.Update(parkingLot);
        }
    }
}
