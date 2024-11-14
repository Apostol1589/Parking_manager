using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.Builder
{
    public interface IVehicleBuilder
    {
        IVehicleBuilder SetLicencePlate(string licencePlate);
        IVehicleBuilder SetMark(string mark);
        IVehicleBuilder SetModel(string model);
        IVehicleBuilder SetColor(string color);
        Vehicle Build();
    }
}
