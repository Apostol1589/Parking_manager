using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Contracts;
using ParkingManager.Domain.Entities;
namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Commands.Create
{
    public class CreateParkingLotCommandHandler : ICommandHandler<CreateParkingLotCommand, int>
    {
        private readonly IParkingLotRepository _repository;

        public CreateParkingLotCommandHandler(IParkingLotRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateParkingLotCommand command, CancellationToken cancellationToken)
        {
            var parkingLot = new ParkingLot
            {
                Name = command.Name,
                Location = command.Location
            };

            await _repository.Create(parkingLot);
            return parkingLot.Id;
        }
    }
}
