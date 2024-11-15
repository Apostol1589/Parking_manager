using ParkingManager.Application.CQRS.Core;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Infrastructure.Repositories.ParkingLotRepo;

namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Commands.Delete
{

    public class DeleteParkingLotCommandHandler : ICommandHandler<DeleteParkingLotCommand>
    {
        private readonly IParkingLotRepository _repository;

        public DeleteParkingLotCommandHandler(IParkingLotRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteParkingLotCommand command, CancellationToken cancellationToken)
        {
            var parkingLot = await _repository.Get(command.Id);
            if (parkingLot == null)
            {
                throw new KeyNotFoundException($"Parking lot with ID {command.Id} not found.");
            }

            await _repository.Delete(command.Id);
        }
    }
}
