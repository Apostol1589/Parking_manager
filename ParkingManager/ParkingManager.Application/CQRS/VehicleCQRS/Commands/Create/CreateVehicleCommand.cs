using ParkingManager.Application.CQRS.Core;

namespace ParkingManager.Application.CQRS.VehicleCQRS.Commands.Create
{
    public class CreateVehicleCommand : ICommand<int>
    {
        public string LicencePlate { get; }
        public string Mark { get; }
        public string Model { get; }
        public string Color { get; }

        public CreateVehicleCommand(string licencePlate, string mark, string model, string color)
        {
            LicencePlate = licencePlate;
            Mark = mark;
            Model = model;
            Color = color;
        }
    }
}
