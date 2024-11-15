using ParkingManager.Application.CQRS.Core;

namespace ParkingManager.Application.CQRS.VehicleCQRS.Commands.Update
{
    public class UpdateVehicleCommand : ICommand
    {
        public int Id { get; }
        public string LicencePlate { get; }
        public string Mark { get; }
        public string Model { get; }
        public string Color { get; }

        public UpdateVehicleCommand(int id, string licencePlate, string mark, string model, string color)
        {
            Id = id;
            LicencePlate = licencePlate;
            Mark = mark;
            Model = model;
            Color = color;
        }
    }
}
