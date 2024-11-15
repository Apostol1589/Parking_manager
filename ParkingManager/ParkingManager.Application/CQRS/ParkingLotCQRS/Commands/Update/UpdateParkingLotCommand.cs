
using ParkingManager.Application.CQRS.Core;

namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Commands.Update
{
    public class UpdateParkingLotCommand : ICommand
    {
        public int Id { get; }
        public string Name { get; }
        public string Location { get; }

        public UpdateParkingLotCommand(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
    }
}
