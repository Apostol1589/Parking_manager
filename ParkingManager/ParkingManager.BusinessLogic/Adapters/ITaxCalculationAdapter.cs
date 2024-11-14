using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.Adapters
{
    public interface ITaxCalculationAdapter
    {
        public decimal CalculateTax(Vehicle vehicle, ParkingLot lot);
    }
}
