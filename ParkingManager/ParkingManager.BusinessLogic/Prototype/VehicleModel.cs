
namespace ParkingManager.BusinessLogic.Prototype
{
    public class VehicleModel : ICloneable
    {
        public string LicencePlate { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public VehicleModel(string licencePlate, string mark, string model, string color)
        {
            LicencePlate = licencePlate;
            Mark = mark;
            Model = model;
            Color = color;
        }

        public object Clone()
        {
            return new VehicleModel(LicencePlate, Mark, Model, Color);
        }
    }
}
