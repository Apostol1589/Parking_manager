using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.Contracts
{
    public interface IVehicleService
    {
        Task<IReadOnlyList<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicleById(int id);
        Task Update(Vehicle vehicle);
        Task Create(Vehicle vehicle);
        Task Remove(int id);
    }
}
