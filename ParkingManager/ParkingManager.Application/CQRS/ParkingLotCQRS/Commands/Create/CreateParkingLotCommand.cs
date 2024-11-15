using ParkingManager.Application.CQRS.Core;

namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Commands.Create
{
    public class CreateParkingLotCommand : ICommand<int>
    {
        public string Name { get; }
        public string Location { get; }

        public CreateParkingLotCommand(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
