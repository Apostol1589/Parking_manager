using ParkingManager.Domain.Contracts;
using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IReadOnlyList<Vehicle>> GetAllVehicles()
        {
            return await _vehicleRepository.Get();
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Vehicle ID must be a positive integer.", nameof(id));
            }

            var vehicle = await _vehicleRepository.Get(id);
            if (vehicle == null)
            {
                throw new KeyNotFoundException($"No vehicle found with ID {id}.");
            }

            return vehicle;
        }

        public async Task Update(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null.");
            }

            if (vehicle.Id <= 0)
            {
                throw new ArgumentException("Vehicle ID must be a positive integer.", nameof(vehicle.Id));
            }

            if (string.IsNullOrWhiteSpace(vehicle.LicencePlate) ||
                string.IsNullOrWhiteSpace(vehicle.Mark) ||
                string.IsNullOrWhiteSpace(vehicle.Model) ||
                string.IsNullOrWhiteSpace(vehicle.Color))
            {
                throw new ArgumentException("All vehicle details (LicencePlate, Mark, Model, and Color) must be provided.");
            }

            await _vehicleRepository.Update(vehicle);
        }

        public async Task Create(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(vehicle.LicencePlate) ||
                string.IsNullOrWhiteSpace(vehicle.Mark) ||
                string.IsNullOrWhiteSpace(vehicle.Model) ||
                string.IsNullOrWhiteSpace(vehicle.Color))
            {
                throw new ArgumentException("All vehicle details (LicencePlate, Mark, Model, and Color) must be provided.");
            }

            await _vehicleRepository.Create(vehicle);
        }

        public async Task Remove(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Vehicle ID must be a positive integer.", nameof(id));
            }

            var vehicle = await _vehicleRepository.Get(id);
            if (vehicle == null)
            {
                throw new KeyNotFoundException($"No vehicle found with ID {id}.");
            }

            await _vehicleRepository.Delete(id);
        }
    }

}
