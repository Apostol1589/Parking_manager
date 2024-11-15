using ParkingManager.Application.CQRS.Core;

namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Commands.Delete
{
    public class DeleteParkingLotCommand : ICommand
    {
        public int Id { get; }

        public DeleteParkingLotCommand(int id)
        {
            Id = id;
        }
    }
}
