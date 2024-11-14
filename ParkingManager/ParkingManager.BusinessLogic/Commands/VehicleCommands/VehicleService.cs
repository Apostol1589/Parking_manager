using Microsoft.Extensions.Logging;
using ParkingManager.BusinessLogic.ChainOfResponsibility.ValidationHandling;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.DataAccess.Entities;
using ParkingManager.DataAccess.Repositories.VehicleRepo;

namespace ParkingManager.BusinessLogic.Commands.VehicleCommands
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILoggerFactory _loggerFactory;

        public VehicleService(IVehicleRepository vehicleRepository, ILoggerFactory loggerFactory)
        {
            _vehicleRepository = vehicleRepository;
            _loggerFactory = loggerFactory;
        }

        private void ValidateVehicle(Vehicle vehicle)
        {
            var licencePlateValidator = new LicencePlateValidationHandler(_loggerFactory);
            var markValidator = new MarkValidationHandler(_loggerFactory);
            var modelValidator = new ModelValidationHandler(_loggerFactory);

            licencePlateValidator.SetNext(markValidator).SetNext(modelValidator);

            licencePlateValidator.Handle(vehicle);
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

        public async Task Create(Vehicle vehicle)
        {
            ValidateVehicle(vehicle);

            var command = new CreateVehicleCommand(_vehicleRepository, vehicle);
            var invoker = new CommandInvoker();
            invoker.AddCommand(command);
            await invoker.ExecuteCommandsAsync();
        }

        public async Task Update(Vehicle vehicle)
        {
            ValidateVehicle(vehicle);

            var command = new UpdateVehicleCommand(_vehicleRepository, vehicle);
            var invoker = new CommandInvoker();
            invoker.AddCommand(command);
            await invoker.ExecuteCommandsAsync();
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

            var command = new RemoveVehicleCommand(_vehicleRepository, id);
            var invoker = new CommandInvoker();
            invoker.AddCommand(command);
            await invoker.ExecuteCommandsAsync();
        }

    }
}
