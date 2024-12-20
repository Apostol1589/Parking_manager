﻿using Microsoft.Extensions.Logging;
using ParkingManager.BusinessLogic.ChainOfResponsibility.ValidationHandling;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.BusinessLogic.Enumerator;
using ParkingManager.DataAccess.Entities;
using ParkingManager.DataAccess.Repositories.VehicleRepo;


namespace ParkingManager.BusinessLogic.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILoggerFactory _loggerFactory;

        public VehicleService(IVehicleRepository vehicleRepository,
            ILoggerFactory loggerFactory)
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

        public async Task Update(Vehicle vehicle)
        {
            ValidateVehicle(vehicle);
            await _vehicleRepository.Create(vehicle);
        }

        public async Task Create(Vehicle vehicle)
        {
            ValidateVehicle(vehicle);
            await _vehicleRepository.Update(vehicle);
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

        public async Task Iterator()
        {
            VehicleCollection vehicles = new VehicleCollection();

            var allVehicles = await GetAllVehicles();

            foreach (var vehicle in allVehicles)
            {
                vehicles.AddVehicle(vehicle);
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Mark: {vehicle.Mark}, Model: {vehicle.Model}");
            }
        }

    }

}
